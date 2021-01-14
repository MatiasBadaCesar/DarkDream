using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformMovil : MonoBehaviour
{
    private GameObject playerGO;

    private void Start()
    {

        playerGO = GameObject.FindWithTag("Player2");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().tag == "PlayerGround")
        {
            playerGO.transform.parent = transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().tag == "PlayerGround")
        {
            playerGO.transform.parent = null;
        }
    }
}
