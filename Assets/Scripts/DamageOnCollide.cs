using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class DamageOnCollide : MonoBehaviour
{
	public float damage;
	
	[HideInInspector]
	public GameObject owner;
	
	[HideInInspector]
	public string team;
	
	// Hit something
	void OnTriggerEnter(Collider other)
	{
		// Check it's not your owner
		if (other.gameObject == owner) return;
		
		// Get damageable data, return if none found
		var damageable = other.gameObject.GetComponent<Damageable>();
		if (damageable == null) return;
		
		// Damage
		damageable.Damage(damage, team);
		
		// Destroy self
		Object.Destroy(gameObject);
	}
}
