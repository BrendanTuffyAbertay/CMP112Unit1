using UnityEngine;

public class BulletFly : MonoBehaviour
{
	[HideInInspector]
    public Vector3 moveDir;
    public float speed;
    public float lifespan;

    private double despawnTime;

    void Start()
    {
        despawnTime = Time.time + lifespan;
    }
    // Update is called once per frame
    void Update()
    {
        // Despawn
        if (Time.time > despawnTime)
        {
            Destroy(gameObject);
        }
        
        // Go forward
        transform.position += transform.forward * speed * Time.deltaTime;


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("wall"))
        {
            Debug.Log("Hit wall");
            Destroy(gameObject);
        }
    }


}
    