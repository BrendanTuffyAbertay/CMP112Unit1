using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
	public GameObject player1;
	public GameObject player2;
	
	private Damageable player1damage;
	private Damageable player2damage;

	public Slider P1hBar;
	public TextMeshProUGUI P1bText;
	public TextMeshProUGUI P1sText;

	public Slider P2hBar;
	public TextMeshProUGUI P2bText;
	public TextMeshProUGUI P2sText;
	public int dmg = 10;
	
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		player1damage = player1.GetComponent<Damageable>();
		player2damage = player2.GetComponent<Damageable>();
		P1hBar.maxValue = player1damage.maxHealth;
		P1hBar.value = player1damage.health;
		P1bText.text = "";
		P1sText.text = "";

		P2hBar.maxValue = player2damage.maxHealth;
		P2hBar.value = player2damage.health;
		P2bText.text = "";
		P2sText.text = "";
	}
	
	// Update is called once per frame
	void Update()
	{
		P1hBar.maxValue = player1damage.maxHealth;
		P1hBar.value = player1damage.health;
		P2hBar.maxValue = player2damage.maxHealth;
		P2hBar.value = player2damage.health;
		
		if( player1damage.health <= 0)
		{
			P1bText.text = "You Died";
		}
		if( player2damage.health <= 0)
		{
			P2bText.text = "You Died"; ;
		}
	}
}
