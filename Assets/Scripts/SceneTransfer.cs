using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransfer : MonoBehaviour
{

    public string sceneName;
    public bool player1;
    public bool player2;



    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.CompareTag("Player"))
        {
            player1 = true;
        }
        if (collision.gameObject.CompareTag("Player2"))
        {
            player2 = true;
        }

        if (player1)
        {
            if (player2)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player1 = false;
        }
        if (collision.gameObject.CompareTag("Player2"))
        {
            player2 = false;
        }
    }

}