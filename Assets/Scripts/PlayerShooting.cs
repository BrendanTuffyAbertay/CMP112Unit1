using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	public GameObject bulletPrefab;	
	public float RPM;

	private double timeOfLastShot;
	private float secondsBetweenShots;
	private Damageable damageableData;
	
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		timeOfLastShot = Time.time;
		// Calculate seconds between shots from RPM
		secondsBetweenShots = 1 / (RPM / 60f);
		
		// Get other components
		damageableData = gameObject.GetComponent<Damageable>();
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetButton("Fire1") && Time.time > timeOfLastShot + secondsBetweenShots)
		{
			timeOfLastShot = Time.time;
			GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
			DamageOnCollide bulletDamage = bullet.GetComponent<DamageOnCollide>();
			bulletDamage.team = damageableData.team;
			bulletDamage.owner = gameObject;
		}
	}
}
