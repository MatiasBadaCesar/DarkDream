using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cinematic : MonoBehaviour
{
    public List<Sprite> imagens;
    public SpriteRenderer body1;
    private int imagenNumber;
    public Animator black;
    public GameObject objectosApagar;
    private void Start()
    {
        body1.sprite = imagens[0];
    }

  
    public void NextImagen()
    {
        if (imagenNumber < imagens.Capacity - 1)
        {
            imagenNumber += 1;
            body1.sprite = imagens[imagenNumber];
        }
        else
        {
            LoadScene();
        }
    }
    public void PrevImagen()
    {
        if (imagenNumber > 0)
        {
            imagenNumber -= 1;
            body1.sprite = imagens[imagenNumber];
        }
    }

    private void LoadScene()
    {
       black.SetBool("Cerrar", true);
        objectosApagar.SetActive(false);
    }
}
