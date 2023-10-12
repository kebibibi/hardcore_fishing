using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public Transform ovi;
    public Camera main;
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

            Vector3 huoneAlku = new Vector3(-38, 5, -935);

            if (doorDir.magnitude < distance)
            {
                transform.position = huoneAlku;
                player.playerSpeed = 50;
                player.gravity = -30;
                main.fieldOfView = 90;
            }
        }
    }
}
