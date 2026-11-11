using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	public GameObject bulletPrefab;	
	public KeyCode shootKey = KeyCode.LeftShift;
	
	// GUN DATA
	// REMEMBER TO TRY DE-HARDCODE THIS SOME TIME
	public float RPM; // Rounds per minute
	public bool semiAutomatic; // If true, each trigger pull only fires one shot
	public float bulletDamage; // Damage per shot
	
	// Shotgun data
	public uint pelletsPerShot = 1; // Number of projectiles fired per fire action.
	public float shotgunSpread = 45; // If this gun is a shotgun, fires the pellets in an arc of this many degrees
	
	private double timeOfNextShot;
	private Damageable damageableData;
	
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		timeOfNextShot = Time.time;
		
		// Get other components
		damageableData = gameObject.GetComponent<Damageable>();
	}
	
	// Actually shoots a bullet
	void ShootBullet(float angleOffset)
	{
		GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, angleOffset, 0)));
		DamageOnCollide bulletData = bullet.GetComponent<DamageOnCollide>();
		bulletData.team = damageableData.team;
		bulletData.owner = gameObject;
		bulletData.damage = bulletDamage;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (
			((Input.GetKey(shootKey) && !semiAutomatic) || Input.GetKeyDown(shootKey)) // Either holding down for full-auto, or when pressed for semi-auto
			&& Time.time > timeOfNextShot
		)
		{
			timeOfNextShot = Time.time + 1 / (RPM / 60f);
			
			// If 1 pellet per shot, just shoot once
			if (pelletsPerShot == 1)
			{
				ShootBullet(0);	
			}
			
			// If multiple pellets per shot, shoot multiple times
			else
			{
				var currentSpread = shotgunSpread / 2;
				for (int i = 0; i < pelletsPerShot; i++)
				{
					ShootBullet(currentSpread);
					currentSpread -= shotgunSpread / (pelletsPerShot - 1);
				}
			}
		}
	}
}
