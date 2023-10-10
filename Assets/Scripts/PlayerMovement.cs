using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public Transform cam;

    public float playerSpeed;

    Vector3 forward;
    Vector3 right;
    Vector3 playerDir;

    const string axisY = "Vertical";
    const string axisX = "Horizontal";

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        forward = cam.TransformDirection(Vector3.forward);
        right = cam.TransformDirection(Vector3.right);
    }

    private void FixedUpdate()
    {
        float speedY = Input.GetAxisRaw(axisY);
        float speedX = Input.GetAxisRaw(axisX);

        playerDir = (forward * speedY).normalized + (right * speedX).normalized;

        rb.velocity = new Vector3(playerDir.x * playerSpeed, -5, playerDir.z * playerSpeed);
    }

}
