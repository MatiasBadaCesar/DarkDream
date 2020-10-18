using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1DeadVisted : MonoBehaviour
{
    public Player1 player;
    public void DeadConfirm()
    {
        player.ResetLevel();
    }
}
