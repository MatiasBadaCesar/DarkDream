using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChangeStatesPlayer1 : MonoBehaviour
{
    //Atrivutos y Propiedaes
    public bool skill;
    public bool changeSkill;
    public List<GameObject> objectWhite;
    public List<GameObject> objectBlack;

    //Activar Habilidad
    private void Start()
    {
        if(changeSkill == false)
        {
            skill = true;
        }
        SelectObject();
        ChangeStates();
    }
   
    public void ChangeStates()
    {
        if (skill == true)
        {
            foreach (var obj in objectWhite)
            {
                obj.SetActive(true);
            }

            foreach (var obj in objectBlack)
            {
                obj.SetActive(false);
            }
            skill = false;
        }
        else
        {
            foreach (var obj in objectWhite)
            {
                obj.SetActive(false);
            }

            foreach (var obj in objectBlack)
            {
                obj.SetActive(true);
            }
            skill = true;
        }
    }

    private void SelectObject()
    {
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("White"))
        {
            objectWhite.Add(fooObj);
        }
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Black"))
        {
            objectBlack.Add(fooObj);
        }
    }

}
