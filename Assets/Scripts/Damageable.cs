using UnityEngine;

public class Damageable : MonoBehaviour
{
	public float maxHealth;
	public string team;
	public float overhealPercentage = 0.5f;
	
	[HideInInspector]
	public float health;
	[HideInInspector]
	public float overhealth;
	
	// Damage
	public void Damage(float amount, string sourceTeam)
	{
		// Don't deal negative damage
		if (amount < 0) return;
		
		// Avoiding hitting yourself or friendly fire
		if (sourceTeam == team) return;

		// Damage overhealth first
		if (overhealth > 0)
		{
			overhealth -= amount;
			
			// If out of overhealth, convert the negative overhealth back to damage
			if (overhealth < 0)
			{
				amount = -overhealth;
				overhealth = 0;
			}
			else
			{
				amount = 0;
			}
		}
		
		// Damage health (either by the full damage or whatever's left over after overhealth)
		health -= amount;
		
		// Die
		if (health <= 0)
		{
			Die();
		}
	}
	
	// Heal
	public void Heal(float amount, bool canOverheal)
	{
		// Don't reverse heal
		if (amount < 0) return;
		
		// Heal
		health += amount;
		
		// Keep below max health
		if (health > maxHealth)
		{
			// Try overheal
			if (canOverheal)
			{
				overhealth += health - maxHealth;
				// Max overheal limit
				if (overhealth > maxHealth * overhealPercentage)
				{
					overhealth = maxHealth * overhealPercentage;
				}
			}
			
			// Limit to max health
			health = maxHealth;
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
		
		// Set overhealth to zero.
		overhealth = 0;
	}
}
