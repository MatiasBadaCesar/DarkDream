using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public Animator anim;

    public void Open()
    {
        anim.SetBool("Open", true);
    }
    public void Close()
    {
        anim.SetBool("Open", false);
    }
}
