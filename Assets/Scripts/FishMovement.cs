using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float randomZ;
    public float randomY;

    public float fishSpeed;

    public float timer;

    public Vector3 randomDest;

    void Start()
    {
        randomZ = Random.Range(220f, 410f);
        randomY = Random.Range(-12, -20);

        randomDest = new Vector3(-350, randomY, randomZ);
    }

    void FixedUpdate()
    {
        transform.position =  Vector3.Lerp(transform.position, randomDest, fishSpeed);

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer < 0)
        {
            float fishFall = Mathf.Lerp(transform.position.y, -120, fishSpeed);
            transform.position = new Vector3(transform.position.x, fishFall, transform.position.z);

            if(transform.position.y < -30)
            {
                Destroy(gameObject);
            }
        }
    }
}
