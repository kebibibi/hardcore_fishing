using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public Camera main;

    public GameObject isokala;

    public Material kalamat;
    Color startMat;
    Color endMat;

    public Transform deck;
    public Transform isokalapää;
    public Transform point;

    public float startDistance;
    public float speed;
    public float timer;

    public bool cutsceneON;

    public Vector3 cutsceneStart;
    public float cutscene1rx;

    private void Start()
    {
        isokala.SetActive(false);

        kalamat.color = new Color(1, 1, 1, 0);

        cutsceneON = false;

        cutsceneStart = new Vector3(3, 70, 250);
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
        if (cutsceneON == true)
        {
            startMat = new Color(1, 1, 1, 0);
            endMat = new Color(1, 1, 1, 1);

            isokala.SetActive(true);

            speed += Time.deltaTime / 2;

            kalamat.color = Color.Lerp(startMat, endMat, speed);

            main.transform.position = Vector3.Lerp(cutsceneStart, point.position, speed);

            cutscene1rx = Mathf.Lerp(-40f, -23f, speed);
            main.transform.eulerAngles = new Vector3(cutscene1rx, main.transform.eulerAngles.y, main.transform.eulerAngles.z);
        }

        if (main.transform.position == point.position)
        {

            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            if (timer < 0)
            {
                Vector3 isokalaPoint = new Vector3(2.4f, -60f, 377f);
                isokala.transform.position = Vector3.Lerp(isokala.transform.position, isokalaPoint, 1);
            }

        }
    }
}
