using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public float fishCount;
    public float dist;

    public Transform player;

    void Update()
    {
        Vector3 playerDir = transform.position - player.position;

        if(fishCount >= 5 && playerDir.magnitude < dist)
        {
            gameObject.SetActive(false);
        }
    }
}
