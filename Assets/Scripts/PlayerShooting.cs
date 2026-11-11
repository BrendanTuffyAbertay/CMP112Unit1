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
	void ShootBullet()
	{
		GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
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
			ShootBullet();
		}
	}
}
