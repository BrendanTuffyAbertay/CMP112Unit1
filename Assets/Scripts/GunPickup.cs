using System;
using DefaultNamespace;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
	public string gunName;
	private void OnTriggerEnter(Collider other)
	{
		// Get playerShooting script
		var playerShooting = other.GetComponent<PlayerShooting>();
		
		// If there is no player shooting script, return early
		if (playerShooting == null) return;
		
		// Switch to the new weapon
		switch (gunName)
		{
			case "Shotgun":
				playerShooting.gunData = new GunData_Shotgun();
				break;
			case "Sniper" :
				playerShooting.gunData = new GunData_Sniper();
				break;
			default:
				Debug.LogError("No gun found for gun name " + gunName);
				break;
		}
		
		// Destroy the pickup
		Destroy(gameObject);
	}
}
