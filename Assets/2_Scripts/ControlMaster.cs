using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMaster : MonoBehaviour
{
    public Player1 player1;
    public Player2 player2;
    private bool keyDown;
    public int activePlayer = 1;
    public bool active = true;

    private void Start()
    {
        keyDown = true;
    }

    private void Update()
    {
        if (active == true)
        {
            if (Input.GetKey("down") || Input.GetKey("s"))
            {
                if (keyDown == true)
                {

                    keyDown = false;
                    if (activePlayer == 1)
                    {
                        changePlayer(2);
                    }
                    else
                    {
                        changePlayer(1);
                    }
                }
            }
            else
            {
                keyDown = true;
            }
        }
    }

    public void changePlayer(int player)
    {
        if (player == 1)
        {
            activePlayer = 1;
            player1.Active();
            player2.Desactive();
        }
        if(player == 2)
        {
            activePlayer = 2;
            player1.Desactive();
            player2.Active();
        }
    }
}
