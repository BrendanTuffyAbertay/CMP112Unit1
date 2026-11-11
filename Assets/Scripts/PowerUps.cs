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
    public int accelleration;
    public int healAmount;

	public string powerupText;
	public string powerupSmallText;

	public int duration;
    public int respawnDuration;

    public TextMeshProUGUI P1bText;
	public TextMeshProUGUI P1sText;

	public TextMeshProUGUI P2bText;
	public TextMeshProUGUI P2sText;

    private AudioSource source;
    public AudioClip sound;

    private void Start()
    {
        // add an audio source
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
	{
		

		if (collision.gameObject.CompareTag("Player")) // if p1 collects powerup
		{
			// healing
			P1bText.text = powerupText;
			P1sText.text = powerupSmallText;
			collision.gameObject.GetComponent<Damageable>().Heal(healAmount, true);
            // dmg
            //collision.gameObject.GetComponent<PlayerShooting>().variable += dmg;
            // attack speed
            collision.gameObject.GetComponent<PlayerShooting>().gunData.RPM += attackSpeed;
            // speed
            collision.gameObject.GetComponent<PlayerController>().maxSpeed += speed;
            collision.gameObject.GetComponent<PlayerController>().acceleration += accelleration;

            source.PlayOneShot(sound, 1.0f);
            
            StartCoroutine(PowerUpWareOff1());

			gameObject.transform.Translate(0, -10, 0);

            StartCoroutine(PowerUpRespawn());

        }
		if (collision.gameObject.CompareTag("Player2")) // if p2 collects powerup
		{
			// healing
			P2bText.text = powerupText;
			P2sText.text = powerupSmallText;
			collision.gameObject.GetComponent<Damageable>().Heal(healAmount, true);

            // dmg
            //collision.gameObject.GetComponent<PlayerShooting>().variable += dmg;
            // attack speed
            collision.gameObject.GetComponent<PlayerShooting>().gunData.RPM += attackSpeed;
            // speed
            collision.gameObject.GetComponent<PlayerController>().maxSpeed += speed;
            collision.gameObject.GetComponent<PlayerController>().acceleration += accelleration;

            source.PlayOneShot(sound, 1.0f);

            StartCoroutine(PowerUpWareOff2());

			gameObject.transform.Translate(0, -10, 0);

			StartCoroutine(PowerUpRespawn());


		}

		// power u ponly lasts as long as duration is set
		IEnumerator PowerUpWareOff1()
		{
			yield return new WaitForSeconds(duration);
			P1bText.text = "";
			P1sText.text = "";
            // reset power ups back to default value below:
            collision.gameObject.GetComponent<PlayerShooting>().gunData.RPM -= attackSpeed;
            //collision.gameObject.GetComponent<PlayerShooting>().variable -= dmg;
            collision.gameObject.GetComponent<PlayerController>().maxSpeed -= speed;
            collision.gameObject.GetComponent<PlayerController>().acceleration -= accelleration;
        }

        IEnumerator PowerUpWareOff2()
		{
			yield return new WaitForSeconds(duration);
			P2bText.text = "";
			P2sText.text = "";
            // reset power ups back to default value below:
            collision.gameObject.GetComponent<PlayerShooting>().gunData.RPM -= attackSpeed;
            //collision.gameObject.GetComponent<PlayerShooting>().variable -= dmg;
            collision.gameObject.GetComponent<PlayerController>().maxSpeed -= speed;
            collision.gameObject.GetComponent<PlayerController>().acceleration -= accelleration;
        }

        //power up respawn
        IEnumerator PowerUpRespawn()
        {
            yield return new WaitForSeconds(respawnDuration);
            gameObject.transform.Translate(0, +10, 0);
        }


    }


}
