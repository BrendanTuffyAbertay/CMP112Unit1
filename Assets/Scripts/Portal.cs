using UnityEngine;

public class Portal : MonoBehaviour
{
    public int PosX;
    public int PosY;
    public int PosZ;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag ("Player") || collision.gameObject.CompareTag("Player2"))
        {   
           
            collision.gameObject.transform.position = new Vector3(PosX, PosY, PosZ);
        }
    }
}
