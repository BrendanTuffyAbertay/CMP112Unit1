using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    
    public int health1 = 100;
    public int health2 = 100;

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
        P1hBar.maxValue = health1;
        P1hBar.value = health1;
        P1bText.text = "";
        P1sText.text = "";

        P2hBar.maxValue = health2;
        P2hBar.value = health2;
        P2bText.text = "";
        P2sText.text = "";
    }

    public void hurt()
    {
        health1 -= dmg;
        P1hBar.value = health1;

        health2 -= dmg;
        P2hBar.value = health2;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            hurt();
        }
        if(health1 == 0)
        {
            P1bText.text = "You Died";
        }
        if(health2 == 0)
        {
            P2bText.text = "You Died";
        }
    }
}
