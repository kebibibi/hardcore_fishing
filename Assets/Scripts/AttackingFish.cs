using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackingFish : MonoBehaviour
{
    NavMeshAgent agent;

    PlayerHealth health;
    Bucket bucket;
    public Vector3 destination;

    public float fishHealth;

    public float invTimer;
    public float maxInv;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        health = FindAnyObjectByType<PlayerHealth>();
        bucket = FindAnyObjectByType<Bucket>();
    }

    void Seek(Vector3 location)
    {
        agent.SetDestination(location);
    }

    void Update()
    {
        destination = health.transform.position;

        Seek(destination);

        if(fishHealth <= 0)
        {
            Destroy(gameObject);
            bucket.fishCount++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            health.health--;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (invTimer > 0)
            {
                invTimer -= Time.deltaTime;

                if (invTimer <= 0)
                {
                    health.health--;
                    invTimer = maxInv;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            invTimer = maxInv;
        }
    }
}
