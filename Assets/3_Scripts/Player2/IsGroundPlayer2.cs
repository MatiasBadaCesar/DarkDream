using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGroundPlayer2 : MonoBehaviour
{
    public Player2 player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().tag == "Ground")
        {
            IsGrounded();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().tag == "Ground")
        {
            IsNotGrounded();
        }
    }


    private void IsGrounded()
    {
        player.IsGrounded();
    }
    private void IsNotGrounded()
    {
        //player.IsNotGrounded();
    }

}
