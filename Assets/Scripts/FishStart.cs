using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishStart : MonoBehaviour
{
    public float randomZ;
    public float randomY;
    public float fishSpeed;
    public float timer;
    public float maxTimer;

    public GameObject fish;

    public Vector3 randomStart;

    private void Start()
    {
        randomY = Random.Range(-12, -20);
        randomZ = Random.Range(220f, 410f);

        randomStart = new Vector3(285, randomY, randomZ);
    }

    void FixedUpdate()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer < 0)
        {
            Instantiate(fish, randomStart, transform.rotation);
            timer = maxTimer;
        }
    }
}
