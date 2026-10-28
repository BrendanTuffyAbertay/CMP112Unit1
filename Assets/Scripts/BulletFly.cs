using UnityEngine;

public class BulletFly : MonoBehaviour
{
    public Vector3 moveDir;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        // Go forward
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
    