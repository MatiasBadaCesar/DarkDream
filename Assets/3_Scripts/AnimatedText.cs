using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class AnimatedText : MonoBehaviour
{
    public bool active;
    public int nextScene;
    public float letterPaused = 0.025f;
	public string[] message;
	public Text textComp;
    public GameObject enter;
    public GameObject camara;
    public GameObject imagen;
    public ChangePlayers changePlayer;

    private bool checkNext = false;
    private int lineaActual = 0;

    public void Active()
    {
        active = true;
        changePlayer.Desactive();
        enter.SetActive(true);
        camara.SetActive(true);
        imagen.SetActive(true);
    }
    void Start()
    {
        textComp.text = "";
		StartCoroutine(TypeText(lineaActual));
	}

    private void Update()
    {
        if (active == true)
        {
            if (lineaActual + 1 == message.Length)
            {
                NextLevel();
            }
            if (checkNext)
            {
                //enter.SetActive(true);
            }
            else
            {
                // enter.SetActive(false);
            }

            if (lineaActual < message.Length - 1 && checkNext && Input.GetKeyDown(KeyCode.Return))
            {
                NextText();
            }
        }
    }

    public void NextText()
    {
        lineaActual++;

        checkNext = false;
        textComp.text = "";

        StartCoroutine(TypeText(lineaActual));
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(nextScene);
    }
    IEnumerator TypeText(int line)
    {
        foreach(char letter in message[line].ToCharArray())
        {
            textComp.text += letter;

            yield return 0;
            yield return new WaitForSeconds(letterPaused);
        }

        checkNext = true;
    }

    public int getLineaActual()
    {
        return lineaActual;
    }

    public int getLastLine()
    {
        return message.Length - 1;
    }

    public bool getCheckNext()
    {
        return checkNext;
    }
}
