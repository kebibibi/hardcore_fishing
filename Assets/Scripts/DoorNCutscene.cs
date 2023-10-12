using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorNCutscene : MonoBehaviour
{
    public Transform player;
    public GameObject endScene;

    void Update()
    {
        Vector3 winDis = transform.position - player.position;

        if(winDis.magnitude < 7)
        {
            endScene.SetActive(true);
        }
    }
}
