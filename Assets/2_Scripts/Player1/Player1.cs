using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    //ATRIVUTOS Y PROPIEDADES           ************************************************ MATIAS BADALONI CESARINI ************************************************

    //Objetos Primarios=
    //Personales:
    public GameObject playerCamera1;
    private Rigidbody2D rb2d;
    public ChangeStatesPlayer1 changeStates;

    //Externos:
    public LevelManager levelManager;

    //Estados Generales=
    public bool active;

    //Movimiento=
    //A los lados:
    private float moveHorizontal; //Direccion horizontal donde se movera el jugador (solo incluye derecha o izquierda)
    private float speed; //Velocidad con que corre el jugador  

    //Habilidad=
    private bool keyUp;
    private bool skill;

    //METODOS PRIMARIOS //           ************************************************ MATIAS BADALONI CESARINI ************************************************

    //Activar=
    public void Active()
    {
        active = true;
        playerCamera1.SetActive(true);
    }
    public void Desactive()
    {
        active = false;
        playerCamera1.SetActive(false);

    }

    //General=
    //Principal:
    void Start()
    {
        //Objetos Primarios=
        {
            //Asignar objetos:
            rb2d = GetComponent<Rigidbody2D>();
        }

        //Movimiento=
        {
            speed = 50;
        }

        //Habilidad
        {
            keyUp = true;
        }

        //Asignacion General=
        {
            //Llamado de Metodos:
            if (active == true)
            {
                Active();
            }
        }

    }
    void Update()
    {
        if (active == true)
        {
            //Movimiento=
            {
                moveHorizontal = Input.GetAxis("Horizontal");
                if (Input.GetKey("left") || Input.GetKey("right") || Input.GetKey("a") || Input.GetKey("d"))
                {

                    if (Input.GetKey("left") || Input.GetKey("a"))
                    {
                        transform.position += transform.right * Time.deltaTime * -speed;
                    }
                    if (Input.GetKey("right") || Input.GetKey("d"))
                    {
                        transform.position += transform.right * Time.deltaTime * speed;
                    }
                }
                else
                {
                    //repose
                }
            }

            //Habilidad= 
            {
                if (Input.GetKey("up") || Input.GetKey("w"))
                {
                    if (keyUp == true)
                    {
                        keyUp = false;
                        Skill();
                    }
                }
                else
                {
                    keyUp = true;
                }
            }
        }
    }

    //Secundario:
    //habilidad=
    private void Skill()
    {
        changeStates.ChangeStates();
    }

    //Terciario:
    //muerte=
    private void Dead()
    {
        levelManager.Restart();
    }
    //collider=
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().tag == "Enemy")
        {
            levelManager.Restart();
        }
    }

}