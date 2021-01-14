using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trout : MonoBehaviour
{
    private GameObject playerGO;

    public GameObject Route;
    public GameObject objective1;
    public GameObject objective2;
    private GameObject objective;

    private bool attack;

    public float speed = 0.7f;

    void Start()
    {
        Route.SetActive(false);
        objective = objective1;
        UpdateStatus();
    }

    void FixedUpdate()
    {
            transform.position = Vector2.MoveTowards(transform.position, objective.transform.position, speed * Time.deltaTime);
    }



    private void OnTriggerStay2D(Collider2D other)
    {
        if (attack == false)
        {
            if (other.gameObject.name == "ObjetiveTrout1")
            {
                objective = objective2;
            }

            if (other.gameObject.name == "ObjetiveTrout2")
            {
                objective = objective1;
            }
        }
    }

    public void Attack()
    {
        objective = playerGO;
        attack = true;
    }

    public void AttackOff()
    {
        objective = objective1;
        attack = false;
    }

    private void UpdateStatus()
    {
        playerGO = GameObject.FindWithTag("Player");
    }

}
