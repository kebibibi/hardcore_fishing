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
        float speedX = playerSpeed * Input.GetAxis(axisY);
        float speedY = playerSpeed * Input.GetAxis(axisX);

        playerDir = (forward * speedX) + (right * speedY);

        rb.velocity = new Vector3(playerDir.x, 0, playerDir.z);
    }
}
