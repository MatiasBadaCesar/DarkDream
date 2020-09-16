using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStatesPlayer1 : MonoBehaviour
{
    //Atrivutos y Propiedaes
    private bool skill;
    public bool changeSkill;
    public GameObject body1;
    public GameObject body2;

    //Activar Habilidad
    private void Start()
    {
        if(changeSkill == false)
        {
            skill = true;
        }
        ChangeStates();
    }
    public void ChangeStates()
    {
        if (skill == true)
        {
            body1.SetActive(true);
            body2.SetActive(false);
            skill = false;
        }
        else
        {
            body1.SetActive(false);
            body2.SetActive(true);
            skill = true;
        }
    }

}
