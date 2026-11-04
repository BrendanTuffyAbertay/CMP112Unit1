using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    public GameObject scriptManager;
    private Ui Ui;

    // Update is called once per frame
    void Start()
    {
        Ui = scriptManager.GetComponent<Ui>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Ui.health1 = 0;
            Ui.P1hBar.value = Ui.health1;
        }

        if (collision.gameObject.CompareTag("Player2"))
        {
            Ui.health2 = 0;
            Ui.P2hBar.value = Ui.health2;
        }
    }
}
