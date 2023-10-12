using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public float fishCount;
    public float dist;

    public Transform player;
    public GameObject fish;
    public GameObject door;

    private void Start()
    {
        door.SetActive(false);
    }

    void Update()
    {
        Vector3 playerDir = transform.position - player.position;

        if(fishCount >= 5 && playerDir.magnitude < dist)
        {
            gameObject.SetActive(false);
            Vector3 fishSpawn = new Vector3(45, 6, -992);

            Instantiate(fish, fishSpawn, transform.rotation);
        }
        if(fishCount >= 10)
        {
            door.SetActive(true);
        }
    }
}
