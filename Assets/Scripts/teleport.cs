using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public Transform ovi;
    PlayerMovement player;

    Cutscene cutscene;

    public float distance;

    private void Start()
    {
        cutscene = GetComponent<Cutscene>();
        player = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (cutscene.cutsceneOFF)
        {
            Vector3 doorDir = transform.position - ovi.position;

            Vector3 huoneAlku = new Vector3(-50, 5, -905);

            if (doorDir.magnitude < distance)
            {
                transform.position = huoneAlku;
                player.playerSpeed = 50;
                player.gravity = -30;
            }
        }
    }
}
