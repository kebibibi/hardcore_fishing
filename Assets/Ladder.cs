using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public float playerDis;

    public bool goingUp;

    public Transform ladder;

    void Update()
    {
        Vector3 ladderDir = transform.position - ladder.position;

        if(ladderDir.magnitude <= playerDis && transform.position.y == 5)
        {
            goingUp = true;
        }
    }
    private void FixedUpdate()
    {
        if (goingUp)
        {
            float up = Mathf.Lerp(transform.position.y, 100, 0.1f * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, up, transform.position.z);

            if(transform.position.y > 49)
            {
                goingUp = false;
            }
        }
    }

}
