using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Camera cam;

	public Vector3 offset;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		cam.transform.position = transform.position + offset;
	}

	// Update is called once per frame
	void Update()
	{
		cam.transform.position = transform.position + offset;
		cam.transform.LookAt(transform.position);
	}
}
