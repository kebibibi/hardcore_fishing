using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackingFish : MonoBehaviour
{
    NavMeshAgent agent;

    public Transform player;
    public Vector3 destination;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Seek(Vector3 location)
    {
        agent.SetDestination(location);
    }

    void Update()
    {
        destination = player.position;

        Seek(destination);
    }
}
