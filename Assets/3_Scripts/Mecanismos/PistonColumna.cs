using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonColumna : MonoBehaviour
{
    public Columna objects;
    public bool permanente;
    public bool invertido;
    private bool unavez;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (unavez == false) {
            if (collision.GetComponent<Collider2D>().tag == "PlayerGround")
            {
                if (invertido == false)
                {
                    objects.Bajar();

                }
                else
                {
                    objects.Subir();
                }
                unavez = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
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

}

