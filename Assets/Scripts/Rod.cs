using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rod : MonoBehaviour
{
    public Transform player;
    public Transform cam;
    public Ladder ladder;
    public AttackingFish fish;

<<<<<<< HEAD
    public ParticleSystem ps;
=======
>>>>>>> 378c6bd7338bfce7ef3ba10f0bc36d6fb44933f6

    public AudioSource audi;

    Vector3 onHandPos;
    Vector3 attack = new Vector3(0.565f, -0.5f, 1.655f);

    public float timer;
    public float maxTimer;
    public bool onHand;
    bool attackOn;

    void Update()
    {
        Vector3 playerDis = transform.position - player.position;

        if (!onHand)
        {
            if (playerDis.magnitude < 8)
            {
                onHand = true;
            }
        }

        if (onHand)
        {
            transform.parent = cam;

            onHandPos = new Vector3(0.6f, -0.5f, 1);
            transform.localPosition = onHandPos;

            transform.localEulerAngles = new Vector3(180, -3, -175);

            if (Input.GetMouseButtonDown(0))
            {
                attackOn = true;
                audi.Play();
            }

            if (attackOn)
            {
                if (timer >= 0)
                {
                    transform.localPosition = attack;
                    timer -= Time.deltaTime;
                    if (timer < 0)
                    {
                        transform.localPosition = onHandPos;
                        timer = maxTimer;
                        attackOn = false;
                    }
                }
            }

            if (ladder.goingUp)
            {
                transform.localPosition = new Vector3(-5, -5, -5);
            }
            else
                return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(attackOn && other.gameObject.CompareTag("Fish"))
        {
            fish = other.gameObject.GetComponent<AttackingFish>();
            fish.fishHealth--;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (attackOn && other.gameObject.CompareTag("Fish"))
        {
            if (timer >= 0)
            {
                transform.localPosition = attack;
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    fish = other.gameObject.GetComponent<AttackingFish>();
                    fish.fishHealth--;
                    transform.localPosition = onHandPos;
                    timer = maxTimer;
                    attackOn = false;
                }
            }
            
        }
    }
}
