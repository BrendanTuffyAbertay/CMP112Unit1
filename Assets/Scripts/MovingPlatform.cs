using System;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    
    public int rangeX = 0;
    public int rangeY = 0;
    public int rangeZ = 0;
    public int speed = 5;
    private Vector3 positionA;
    private Vector3 positionB;
    private bool MovetoA = true;

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
}
