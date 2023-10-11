using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public Transform ovi;

    Cutscene cutscene;

    public float distance;

    private void Start()
    {
        cutscene = GetComponent<Cutscene>();
    }

    void Update()
    {
        if (cutscene.cutsceneOFF)
        {
            Vector3 doorDir = transform.position - ovi.position;

            Vector3 huoneAlku = new Vector3(-60, 5, -330);

            if (doorDir.magnitude < distance)
            {
                Debug.Log("moi");
                transform.position = huoneAlku;
            }
        }
    }
}
