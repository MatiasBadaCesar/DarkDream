using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
   private void Start()
    {
        canvasTextGB = GameObject.FindWithTag("CanvasText");
        canvasText = canvasTextGB.GetComponent<AnimatedText>();

    }
    public int nextScene;
    private GameObject canvasTextGB;
    private AnimatedText canvasText;

    private void NextLevel()
    {
        SceneManager.LoadScene(nextScene);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canvasText.Active();
        //NextLevel();
    }
}
