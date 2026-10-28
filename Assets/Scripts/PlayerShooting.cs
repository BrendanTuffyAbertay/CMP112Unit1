using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	public GameObject bulletPrefab;    
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			Debug.Log(transform.forward);
			GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
		}
	}
}
