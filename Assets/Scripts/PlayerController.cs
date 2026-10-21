using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed;
	public float jumpStrength;
	
	private Vector3 moveDir;
	private Rigidbody rb;
	private bool jumping = false;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		// Get move dir
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
			moveDir += new Vector3(0, 0, 1);
		}
		if (Input.GetKey(KeyCode.D))
		{
			moveDir += new Vector3(0, 0, -1);
		}
		if (moveDir.magnitude > 0)
		{
			moveDir.Normalize();
		}
		
		// Get jump
		if (Input.GetKeyDown(KeyCode.Space))
		{
			rb.AddForce(0, jumpStrength, 0);
		};
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		// Move
		rb.AddForce(moveDir * moveSpeed);
	}
}
