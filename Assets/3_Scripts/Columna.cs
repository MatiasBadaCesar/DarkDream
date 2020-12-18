using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Columna: MonoBehaviour
{
    Animator anim;
    private int fases;
    void Start()
    {
        anim = GetComponent<Animator>();
        Subir();
    }
    void Update()
    {
        
    }

    public void Subir()
    {
        anim.SetBool("Bajar2", false);
    }

    public void Bajar()
    {
        if (fases == 1)
        {
            anim.SetBool("Bajar2", true);
        }
        if (fases==0)
        {
            anim.SetBool("Bajar1", true);
            fases = 1;
        }
    }
}
