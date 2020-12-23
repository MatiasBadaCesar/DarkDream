using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piston : MonoBehaviour
{

    public Animator anim;
    public Puerta puerta;
    public bool permanent;
    private bool open;
    public bool reverse;
    public bool playNow;
    public bool specialTransform;
    public GameObject objectSpecial;

    private void Start()
    {
        if (playNow == true)
        {
            puerta.Open();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (specialTransform == false) {
            if (open == false)
            {
                open = true;
                anim.SetBool("Open", true);
                if (reverse == false)
                {
                    puerta.Open();
                }
                else
                {
                    puerta.Close();
                }
            }
        }
        else
        {
            objectSpecial.tag = "White";

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (specialTransform == false)
        {
            if (open == true)
            {
                if (permanent == false)
                {
                    open = false;
                    anim.SetBool("Open", false);
                    if (reverse == true)
                    {
                        puerta.Open();
                    }
                    else
                    {
                        puerta.Close();
                    }
                }
            }
        }
    }
}
