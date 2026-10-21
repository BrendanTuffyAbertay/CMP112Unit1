using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController3 : MonoBehaviour
{

    private Rigidbody rb;

    public float speed1 = 6.0f;
    public float jumpspeed1 = 8.0f;
    public float gravity1 = 20.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        Vector3 move1 = new Vector3(Input.GetAxis("Horizontal1"), 0, Input.GetAxis("Vertical1"));
        gameObject.transform.Translate(move1 * Time.deltaTime * speed1);
    }

    void FixedUpdate()
    {
        
    }
}
