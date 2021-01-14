using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObject : MonoBehaviour
{
    public GameObject objects;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        objects.SetActive(true);
    }
}
