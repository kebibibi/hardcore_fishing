using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;

    public bool goingUp;

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
}
