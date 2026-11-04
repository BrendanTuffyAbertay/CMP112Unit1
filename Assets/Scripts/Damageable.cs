using UnityEngine;

public class Damageable : MonoBehaviour
{
	public float health;
	public float maxHealth;
	public string team;
	
	// Damage
	void Damage(float amount, string sourceTeam)
	{
		// Check the attack isn't actually a heal
		if (amount < 0) return;
		
		// Avoiding hitting yourself or friendly fire
		if (sourceTeam == team) return;

		// Actually damage
		health -= amount;
		
		// Die
		if (health <= 0)
		{
			Die();
		}
	}

	// Die
	void Die()
	{
		// Placeholder
		Debug.Log("Dead");
	}
	
	void Start()
	{
		// Set health to max health
		health = maxHealth;
	}

	void Update()
	{
		// Make sure health cannot be over max health
		if (health > maxHealth)
		{
			health = maxHealth;
		}
	}
}
