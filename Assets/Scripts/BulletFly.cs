using UnityEngine;

public class BulletFly : MonoBehaviour
{
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Go forward
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }
}
    