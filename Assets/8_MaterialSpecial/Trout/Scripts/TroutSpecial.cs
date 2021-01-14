using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroutSpecial : MonoBehaviour
{
    public Transform trout;

    void FixedUpdate()
    {
        transform.position = new Vector3(trout.position.x , trout.position.y , 0);

    }
}
