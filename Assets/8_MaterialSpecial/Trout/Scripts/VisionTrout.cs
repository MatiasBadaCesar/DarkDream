using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionTrout : MonoBehaviour
{
    public Trout trout;
    public GameObject body;

    private void Start()
    {
        body.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D player)
    {
        if (player.GetComponent<Collider2D>().tag == "Player")
        {
            trout.Attack();
        }
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        if (player.GetComponent<Collider2D>().tag == "Player")
        {
            trout.AttackOff();
        }
    }
}
