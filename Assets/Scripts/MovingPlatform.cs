using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    
    // variables for the range of movement
    public int rangeX = 0;
    public int rangeY = 0;
    public int rangeZ = 0;
    public int speed = 5;
    public Vector3 positionA;
    public Vector3 positionB;
    public bool MovetoA = true;

    // player game object variables
    public GameObject player1;
    public GameObject player2;

    void Start()
    {
        // gets positions of the two ends of platform range
        positionA = new Vector3(transform.position.x + rangeX, transform.position.y + rangeY, transform.position.z + rangeZ);
        positionB = new Vector3(transform.position.x - rangeX, transform.position.y - rangeY, transform.position.z - rangeZ);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Vector3.Distance(transform.position, positionA) < 0.01f)
        {
            // when platform is at point A, set variable to fasle to stop it moving towards a more
            MovetoA = false;
        }
        if(Vector3.Distance(transform.position, positionB) < 0.01f)
        {
            // // when platform is at point b, set variable to true to get it moving towards A
            MovetoA = true;
        }
        if (MovetoA == true)
        {
            // move the platform to point A if variable is true
            transform.position = Vector3.MoveTowards(transform.position, positionA, speed * Time.deltaTime);
        }
        if (MovetoA == false)
        {
            // move platform to B if variable is false
            transform.position = Vector3.MoveTowards(transform.position, positionB, speed * Time.deltaTime);
        }

    }



    private void OnCollisionEnter(Collision collision)
    {
        

        // if player is touching it, make it a child of platofrom so they move together
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
        

        // remove players from being a child of platform when they get off
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
