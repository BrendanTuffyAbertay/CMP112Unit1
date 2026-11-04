using UnityEngine;

public class Damageable : MonoBehaviour
{
	private float health;
	public float maxHealth;
	public string team;
	
	// Damage
	public void Damage(float amount, string sourceTeam)
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
		// Destroy object
		Object.Destroy(gameObject);
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
