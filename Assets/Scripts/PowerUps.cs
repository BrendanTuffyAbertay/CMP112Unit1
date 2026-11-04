using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Diagnostics;


public class PowerUps : MonoBehaviour
{
    
    public int dmg;
    public int attackSpeed;
    public int speed;
    public string powerupText;

    public int duration;

    public TextMeshProUGUI P1bText;
    public TextMeshProUGUI P1sText;

    public TextMeshProUGUI P2bText;
    public TextMeshProUGUI P2sText;
    

    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.CompareTag("Player"))
        {
            P1bText.text = powerupText;
            StartCoroutine(PowerUpWareOff());
        }
        if (collision.gameObject.CompareTag("Player2"))
        {
            
        }

        IEnumerator PowerUpWareOff()
        {
            yield return new WaitForSeconds(duration);
            P1bText.text = "";
        }

    }


}
