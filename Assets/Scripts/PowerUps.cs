using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
//using System.Diagnostics;

public class PowerUps : MonoBehaviour
{
	public GameObject scriptManager;
	public int dmg;
	public int attackSpeed;
	public int speed;
	public int healAmount;

	public string powerupText;
	public string powerupSmallText;

	public int duration;

	public TextMeshProUGUI P1bText;
	public TextMeshProUGUI P1sText;

	public TextMeshProUGUI P2bText;
	public TextMeshProUGUI P2sText;

	private void OnCollisionEnter(Collision collision)
	{
		

		if (collision.gameObject.CompareTag("Player"))
		{
			// healing
			P1bText.text = powerupText;
			P1sText.text = powerupSmallText;
			collision.gameObject.GetComponent<Damageable>().Heal(healAmount, true);
			// dmg

			// attack speed

			// speed

			StartCoroutine(PowerUpWareOff1());

			gameObject.transform.Translate(0, -10, 0);
		}
		if (collision.gameObject.CompareTag("Player2"))
		{
			// healing
			P2bText.text = powerupText;
			P2sText.text = powerupSmallText;
			collision.gameObject.GetComponent<Damageable>().Heal(healAmount, true);

			// dmg

			// attack speed

			// speed

			StartCoroutine(PowerUpWareOff2());

			gameObject.transform.Translate(0, -10, 0);
		}

		IEnumerator PowerUpWareOff1()
		{
			yield return new WaitForSeconds(duration);
			P1bText.text = "";
			P1sText.text = "";
		}

		IEnumerator PowerUpWareOff2()
		{
			yield return new WaitForSeconds(duration);
			P2bText.text = "";
			P2sText.text = "";
		}

	}


}
