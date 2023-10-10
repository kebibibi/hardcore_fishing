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

        Vector3 dirY = forward * speedY;
        Vector3 dirX = right * speedX;

        playerDir = dirX + dirY;

        Vector3 norPD = playerDir.normalized;

        rb.velocity = new Vector3(norPD.x * playerSpeed, -5, norPD.z * playerSpeed);
    }

}
