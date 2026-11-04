using System;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    
    public int rangeX = 0;
    public int rangeY = 0;
    public int rangeZ = 0;
    public int speed = 5;
    public Vector3 positionA;
    public Vector3 positionB;
    public bool MovetoA = true;

    public GameObject player1;
    public GameObject player2;

    void Start()
    {
        positionA = new Vector3(transform.position.x + rangeX, transform.position.y + rangeY, transform.position.z + rangeZ);
        positionB = new Vector3(transform.position.x - rangeX, transform.position.y - rangeY, transform.position.z - rangeZ);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Vector3.Distance(transform.position, positionA) < 0.01f)
        {
            MovetoA = false;
        }
        if(Vector3.Distance(transform.position, positionB) < 0.01f)
        {
            MovetoA = true;
        }
        if (MovetoA == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, positionA, speed * Time.deltaTime);
        }
        if (MovetoA == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, positionB, speed * Time.deltaTime);
        }

    }



    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.CompareTag("Player"))
        {
            player1.transform.parent = this.gameObject.transform;
        }
        if (collision.gameObject.CompareTag("Player2"))
        {
            player2.transform.parent = this.gameObject.transform;
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        

        if (collision.gameObject.CompareTag("Player"))
        {
            player1.transform.parent = null;
        }
        if (collision.gameObject.CompareTag("Player2"))
        {
            player2.transform.parent = null;
        }

    }

}
