using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayers : MonoBehaviour
{
    public Player1 player1;
    public Player2 player2;
    private GameObject playerGameObject1;
    private GameObject playerGameObject2;
    public AudioSource sound;
    private bool keyDown;
    public int activePlayer = 1;
    public bool active = true;

    private void Start()
    {
        keyDown = true;
        if (active == true)
        {
            playerGameObject1 = GameObject.FindWithTag("Player1");
            player1 = playerGameObject1.GetComponent<Player1>();
            playerGameObject2 = GameObject.FindWithTag("Player2");
            player2 = playerGameObject2.GetComponent<Player2>();
        }
    }

    private void Update()
    {
        if (active == true)
        {
            if (Input.GetKey("s"))
            {
                if (keyDown == true)
                {
                    sound.Play();
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

    public void Desactive()
    {
        player1.Desactive();
        if (active == true)
        {
            player2.Desactive();
        }
    }
}
