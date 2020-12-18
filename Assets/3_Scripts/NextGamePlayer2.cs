using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextGamePlayer2 : MonoBehaviour
{
    public int nextScene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().tag == "Player2")
        {
             NextLevel();
        }
    }
    private void NextLevel()
    {
        SceneManager.LoadScene(nextScene);
    }
}
