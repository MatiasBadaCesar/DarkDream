using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DeadVisted : MonoBehaviour
{
    public Player2 player;
    public void DeadConfirm()
    {
        player.ResetLevel();
    }
}
