using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController2 : MonoBehaviour
{

    private Rigidbody rb;

    public float speed = 6.0f;
    public float jumpspeed = 8.0f;
    public float gravity = 20.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        gameObject.transform.Translate(move * Time.deltaTime * speed);
    }

    void FixedUpdate()
    {
        
    }
}
