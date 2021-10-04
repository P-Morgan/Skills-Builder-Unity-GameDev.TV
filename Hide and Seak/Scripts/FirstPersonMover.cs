// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMover : MonoBehaviour
{
    [SerializeField] float mouseSpeed = 3f;
    [SerializeField] float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {   
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * mouseSpeed, Space.World);
        transform.Rotate(transform.right, -Input.GetAxis("Mouse Y") * mouseSpeed, Space.World);
        Vector3 forwardOnPlane = Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = (forwardOnPlane * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal")) * moveSpeed;
    }
}
