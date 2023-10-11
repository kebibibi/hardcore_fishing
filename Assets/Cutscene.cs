using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public Camera main;
    public Transform deck;

    public float startDistance;

    public bool cutsceneON;

    private void Start()
    {
        cutsceneON = false;
    }

    void Update()
    {
        Vector3 deckDir = transform.position - deck.position;

        if (deckDir.magnitude < startDistance)
        {
            cutsceneON = true;
            CutsceneOn();
        }
    }

    public void CutsceneOn()
    {
        main.transform.position = new Vector3(3, 70, 250);
        main.transform.eulerAngles = new Vector3(-30, 0, 0);
    }
}
