using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey("r"))
        {
            Restart();
        }
    }
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
