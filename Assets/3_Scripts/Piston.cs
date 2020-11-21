using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piston : MonoBehaviour
{
    public GameObject objects;
    public bool permanent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        objects.SetActive(false);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (permanent == false)
        {
            objects.SetActive(true);
        }
    }
}
