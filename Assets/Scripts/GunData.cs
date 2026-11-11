using System;
using System.Linq;
using UnityEngine;

[Serializable]
public class GunData
{
	// Data used by all weapons
	public float RPM = 500; // Rounds per minute
	public bool semiAutomatic = false; // If true, each trigger pull only fires one shot
	public float bulletDamage = 15; // Damage per shot (or in the case of shotgun-type weapons, per pellet)
	
	// Shotgun data
	public uint pelletsPerShot = 1; // Number of projectiles fired per fire action.
	public float shotgunSpread = 45; // If this gun is a shotgun, fires the pellets in an arc of this many degrees
	
	// Sounds
	public String gunshotFolder = "Sounds/Gunshot/Rifle";
	public AudioClip[] gunShotSounds = Array.Empty<AudioClip>();
	public Boolean hasHadSoundsGenerated = false;
	
	public void GenerateGunSounds()
	{
		Debug.Log("Generating gun sounds");
		gunShotSounds = Resources.LoadAll<AudioClip>(gunshotFolder);
		hasHadSoundsGenerated = true;
	}
}
