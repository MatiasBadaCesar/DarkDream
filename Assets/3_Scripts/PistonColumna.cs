using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonColumna : MonoBehaviour
{
    public Columna objects;
    public bool permanente;
    public bool invertido;
    public bool onlywhite;
    public bool animActive;
    public GameObject[] activar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (onlywhite == false)
        {
            if (invertido == false)
            {
                objects.Bajar();

                if (animActive == true)
                {
                    activar[0].SetActive(true);
                    activar[1].SetActive(true);
                }
            }
            else
            {
                objects.Subir();
            }
        }
        else
        {
            if (collision.GetComponent<Collider2D>().tag == "White")
            {
                objects.Subir();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (onlywhite == false)
        {
            if (permanente == false)
            {
                if (invertido == false)
                {
                    objects.Subir();
                }
                else
                {
                    objects.Bajar();
                }
            }
        }
        else
        {
            if (collision.GetComponent<Collider2D>().tag == "White")
            {
                if (animActive == false)
                {
                    objects.Bajar();
                }
            }
        }
    }
}

