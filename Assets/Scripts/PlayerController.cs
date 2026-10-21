using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed;
	public float jumpStrength;
	public float groundedDistance;
	public float amountOfCoyoteTime;
	
	private Vector3 moveDir;
	private Rigidbody rb;
	private bool grounded = true;
	private float lastGroundedTime;
	private bool hasJumped;
	
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		// Get move dir
		moveDir = new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal"));
		if (moveDir.magnitude > 0)
		{
			moveDir.Normalize();
		}
		else
		{
			// Go towards zero
			moveDir = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z).normalized * - 1;
		}

		// Get grounded
		grounded = Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, groundedDistance);
		if (grounded)
		{
			lastGroundedTime = Time.time;
			hasJumped = false;
		}

		// Get jump
		if (Input.GetKeyDown(KeyCode.Space) && amountOfCoyoteTime < Time.time - lastGroundedTime && !hasJumped)
		{
			rb.AddForce(0, jumpStrength, 0);
			hasJumped = true;
		};
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		// Move
		rb.AddForce(moveDir * moveSpeed);
	}
}
