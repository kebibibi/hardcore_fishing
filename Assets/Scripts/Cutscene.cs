using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public Camera main;

    public GameObject isokala;
    public GameObject pikkukala;
    public GameObject player;

    public Material kalamat;
    Color startMat;
    Color endMat;

    public Transform deck;
    public Transform isokalapää;
    public Transform point;

    public float startDistance;
    public float speed;

    public float timer1;
    public float timer2;

    public bool cutsceneON;
    public bool cutsceneP1;
    public bool cutsceneOFF;

    Vector3 cutsceneStart;
    Vector3 cutscene1;
    public float cutscene1rx;

    private void Start()
    {
        isokala.SetActive(false);
        pikkukala.SetActive(false);

        kalamat.color = new Color(1, 1, 1, 0);

        cutsceneON = false;
        cutsceneOFF = false;
        cutsceneP1 = false;

        cutsceneStart = new Vector3(3, 70, 250);
    }

    void Update()
    {
        Vector3 deckDir = transform.position - deck.position;

        if (deckDir.magnitude < startDistance && cutsceneOFF == false)
        {
            cutsceneON = true;
            cutsceneP1 = true;
            CutsceneOn();
        }
    }

    public void CutsceneOn()
    {
        if (cutsceneON == true && cutsceneP1 == true)
        {
            startMat = new Color(1, 1, 1, 0);
            endMat = new Color(1, 1, 1, 1);

            isokala.SetActive(true);

            speed += Time.deltaTime / 2;

            kalamat.color = Color.Lerp(startMat, endMat, speed);

            main.transform.position = Vector3.Lerp(cutsceneStart, point.position, speed);

            cutscene1rx = Mathf.Lerp(-40f, -23f, speed);
            cutscene1 = new Vector3(cutscene1rx, 0, 0);

            main.transform.eulerAngles = cutscene1;
        }

        if (main.transform.position == point.position)
        {
            speed -= Time.deltaTime / 2;

            cutsceneP1 = false;
            if (timer1 > 0)
            {
                timer1 -= Time.deltaTime;
            }
            if (timer1 < 0)
            {
                Vector3 isokalaPoint = new Vector3(2.4f, -60f, 377f);
                isokala.transform.position = Vector3.Lerp(isokala.transform.position, isokalaPoint, 1);

                if(timer2 > 0)
                {
                    timer2 -= Time.deltaTime;
                }

                if (timer2 < 5)
                {
                    Vector3 doorDirection = new Vector3(0, 150, 0);
                    Vector3 doorDirLerp = Vector3.Lerp(main.transform.eulerAngles, doorDirection, 1);

                    main.transform.eulerAngles = doorDirLerp;
                }

                if(timer2 < 0)
                {
                    isokala.SetActive(false);
                    pikkukala.SetActive(true);

                    main.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3, player.transform.position.z);

                    cutsceneON = false;
                    cutsceneOFF = true;
                }
            }
        }
    }
}
