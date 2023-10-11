using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTurn : MonoBehaviour
{
    public float Sensitivity
    { get { return sensitivity; }
        set { sensitivity = value; }
    }

    [Range(0.1f, 9f)] [SerializeField] float sensitivity = 2f;
    [Range(0f, 90f)] [SerializeField] float yRotationLimit = 88f;

    Vector2 rotation = Vector2.zero;

    public Cutscene cutscene;

    const string xAxis = "Mouse X";
    const string yAxis = "Mouse Y";

    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if(cutscene.cutsceneON == false)
        {
            rotation.x += Input.GetAxis(xAxis) * sensitivity;
            rotation.y += Input.GetAxis(yAxis) * -sensitivity;
            rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);

            var quatX = Quaternion.AngleAxis(rotation.x, Vector3.up);
            var quatY = Quaternion.AngleAxis(rotation.y, Vector3.right);

            transform.localRotation = quatX * quatY;
        }
    }
}
