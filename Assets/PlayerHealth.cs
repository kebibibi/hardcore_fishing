using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float invTimer;
    public float maxInv;

    void Start()
    {
        health = 10;
    }

    private void Update()
    {
        if(health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fish"))
        {
            health--;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Fish"))
        {
            if (invTimer > 0)
            {
                invTimer -= Time.deltaTime;

                if (invTimer <= 0)
                {
                    health--;
                    invTimer = maxInv;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Fish"))
        {
            invTimer = maxInv;
        }
    }
}
