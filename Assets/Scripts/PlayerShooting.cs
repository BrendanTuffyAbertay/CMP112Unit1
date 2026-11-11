using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerShooting : MonoBehaviour
{
	public GameObject bulletPrefab;	
	public KeyCode shootKey = KeyCode.LeftShift;
	
	// GUN DATA
	[NonSerialized] public GunData gunData = new GunData_BasicRifle();
	
	private double timeOfNextShot;
	private Damageable damageableData;
	private AudioSource audioSource;
	
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		timeOfNextShot = Time.time;
		
		// Get other components
		damageableData = gameObject.GetComponent<Damageable>();
		audioSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Actually shoots a bullet
	void ShootBullet(float angleOffset)
	{
		GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, angleOffset, 0)));
		DamageOnCollide bulletData = bullet.GetComponent<DamageOnCollide>();
		bulletData.team = damageableData.team;
		bulletData.owner = gameObject;
		bulletData.damage = gunData.bulletDamage;
	}
	
	// Update is called once per frame
	void Update()
	{
		// Check sounds generated, generate if not
		if (!gunData.hasHadSoundsGenerated)
		{
			Debug.Log("Need to generate gun sounds");
			gunData.GenerateGunSounds();
		}
		if (
			((Input.GetKey(shootKey) && !gunData.semiAutomatic) || Input.GetKeyDown(shootKey)) // Either holding down for full-auto, or when pressed for semi-auto
			&& Time.time > timeOfNextShot
		)
		{
			timeOfNextShot = Time.time + 1 / (gunData.RPM / 60f);
			
			// If 1 pellet per shot, just shoot once
			if (gunData.pelletsPerShot == 1)
			{
				ShootBullet(0);	
			}
			
			// If multiple pellets per shot, shoot multiple times
			else
			{
				var currentSpread = gunData.shotgunSpread / 2;
				for (int i = 0; i < gunData.pelletsPerShot; i++)
				{
					ShootBullet(currentSpread);
					currentSpread -= gunData.shotgunSpread / (gunData.pelletsPerShot - 1);
				}
			}
			
			// Play gunshot
			Debug.Log(gunData.gunShotSounds.Length);
			audioSource.PlayOneShot(gunData.gunShotSounds[Random.Range(0, gunData.gunShotSounds.Length)]);
		}
	}
}
