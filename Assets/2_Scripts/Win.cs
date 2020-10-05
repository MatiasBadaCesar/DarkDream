using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public int nextScene;

    private void NextLevel()
    {
        SceneManager.LoadScene(nextScene);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        NextLevel();
    }
}
