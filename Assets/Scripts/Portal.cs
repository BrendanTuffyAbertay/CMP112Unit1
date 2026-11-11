using UnityEngine;

public class Portal : MonoBehaviour
{
    public int PosX;
    public int PosY;
    public int PosZ;

    private void OnCollisionEnter(Collision collision)
    {
        // if either player touch the object
        if (collision.gameObject.CompareTag ("Player") || collision.gameObject.CompareTag("Player2"))
        {   
           // transform that player to the chosen position
            collision.gameObject.transform.position = new Vector3(PosX, PosY, PosZ);
        }
    }
}
