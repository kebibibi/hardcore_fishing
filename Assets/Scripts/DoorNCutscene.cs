using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorNCutscene : MonoBehaviour
{
    public Transform player;

    public GameObject endScene;
    public GameObject hahmo;


    void Update()
    {
        Vector3 winDis = transform.position - player.position;

        if(winDis.magnitude < 7)
        {
            hahmo.SetActive(true);
            endScene.SetActive(true);
        }
    }
}
