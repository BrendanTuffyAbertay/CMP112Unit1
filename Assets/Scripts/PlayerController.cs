using System;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float acceleration;
	public float jumpStrength;
	public float groundedDistance;
	public float amountOfCoyoteTime;
	public float maxSpeed;

	public string horizontalAxisName = "Horizontal";
	public string verticalAxisName = "Vertical";
	
	private Vector3 moveDir;
	private Rigidbody rb;
	private bool grounded = true;
	private float lastGroundedTime = 0f;
	private bool hasJumped = false;
	
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		lastGroundedTime = Time.time;
	}

	void Update()
	{
		// Get move dir
		moveDir = new Vector3(Input.GetAxis(verticalAxisName), 0, -Input.GetAxis(horizontalAxisName));
		if (moveDir.magnitude > 0)
		{
			moveDir.Normalize();
			
			// Aim
			transform.rotation = Quaternion.Euler(0, ((float)Math.Atan2(moveDir.x, -moveDir.z) * Mathf.Rad2Deg) * -1 + 90, 0);
		}
		else
		{
			// Go towards zero
			moveDir = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z).normalized * -1;
		}

		// Get grounded
		grounded = Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, groundedDistance);
		if (grounded)
		{
			lastGroundedTime = Time.time;
			hasJumped = false;
		}

		// Get jump
		if (
			Input.GetKeyDown(KeyCode.Space) &&
			amountOfCoyoteTime > Time.time - lastGroundedTime && 
			!hasJumped
		) {
			rb.AddForce(0, jumpStrength, 0);
			hasJumped = true;
		};
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		var attemptedMove = moveDir * acceleration;
		rb.AddForce(attemptedMove);
		// Add counterforce if going too fast

		if (new Vector2(rb.linearVelocity.x, rb.linearVelocity.z).magnitude > maxSpeed)
		{
			rb.AddForce(-attemptedMove);
		}
	}
}
