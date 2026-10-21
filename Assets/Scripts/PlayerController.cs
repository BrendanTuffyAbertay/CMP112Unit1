using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed;
	
	private Vector3 moveDir;
	private Rigidbody rb;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		moveDir = new Vector3();
		if (Input.GetKey(KeyCode.W))
		{
			moveDir += new Vector3(1, 0, 0);
		}
		if (Input.GetKey(KeyCode.S))
		{
			moveDir += new Vector3(-1, 0, 0);
		}
		if (Input.GetKey(KeyCode.A))
		{
			moveDir += new Vector3(0, 0, -1);
		}
		if (Input.GetKey(KeyCode.D))
		{
			moveDir += new Vector3(0, 0, 1);
		}
		if (moveDir.magnitude > 0)
		{
			moveDir.Normalize();
		}
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		Debug.Log(moveDir * moveSpeed);
		rb.AddForce(moveDir * moveSpeed );
	}
}
