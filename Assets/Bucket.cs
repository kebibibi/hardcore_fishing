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
    public GameObject hook;

    private void Start()
    {
        door.SetActive(false);
    }

    void Update()
    {
        Vector3 playerDir = transform.position - player.position;
        Vector3 hookToPlayer = player.position - hook.transform.position;
        Vector3 bucketHook = new Vector3(-18.3f, 6.8f, -935.75f);

        if(fishCount == 5 && playerDir.magnitude < dist)
        {
            Vector3 fishSpawn = new Vector3(45, 6, -992);
            Vector3 fishSpawn1 = new Vector3(46, 3.59f, -934);

            transform.position = new Vector3(0, 0, 0);

            Instantiate(fish, fishSpawn, transform.rotation);
            Instantiate(fish, fishSpawn, transform.rotation);
            Instantiate(fish, fishSpawn1, transform.rotation);
            Instantiate(fish, fishSpawn1, transform.rotation);  
            Instantiate(fish, fishSpawn1, transform.rotation);
        }

        if(fishCount >= 10 && hookToPlayer.magnitude > 9)
        {
            transform.position = bucketHook;
            door.SetActive(true);
        }
    }
}
