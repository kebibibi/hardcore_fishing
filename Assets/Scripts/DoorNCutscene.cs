using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorNCutscene : MonoBehaviour
{
    public Transform player;
    public Material blood;

    public GameObject endScene;
    public GameObject hahmo;

    void Update()
    {
        Vector3 winDis = transform.position - player.position;

        if(winDis.magnitude < 7)
        {
            Color nolla = new Color(1, 1, 1, 0);
            Color sata = new Color(1, 1, 1, 1);

            hahmo.SetActive(true);
            endScene.SetActive(true);
            blood.color = Color.Lerp(nolla, sata, 0.1f * Time.deltaTime);
        }
    }
}
