using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public Transform cam;
    public GameObject cutsceneCam;

    public float playerSpeed;
    public float gravity;

    public GameObject player;
    public GameObject hahmo;

    Vector3 forward;
    Vector3 right;
    Vector3 playerDir;

    Cutscene cutscene;

    const string axisY = "Vertical";
    const string axisX = "Horizontal";

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cutscene = GetComponent<Cutscene>();
        cutsceneCam.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        hahmo.SetActive(false);
    }

    void Update()
    {
        if(cutscene.cutsceneON == false)
        {
            forward = cam.TransformDirection(Vector3.forward);
            right = cam.TransformDirection(Vector3.right);
        }
    }

    private void FixedUpdate()
    {
        if(cutscene.cutsceneON == false)
        {
            float speedY = Input.GetAxisRaw(axisY);
            float speedX = Input.GetAxisRaw(axisX);

            Vector3 dirY = forward * speedY;
            Vector3 dirX = right * speedX;

            playerDir = dirX + dirY;

            Vector3 norPD = playerDir.normalized;

            rb.velocity = new Vector3(norPD.x * playerSpeed, gravity, norPD.z * playerSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

}
