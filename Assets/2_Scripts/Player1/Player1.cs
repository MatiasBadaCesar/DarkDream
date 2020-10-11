using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    //ATRIVUTOS Y PROPIEDADES           ************************************************ MATIAS BADALONI CESARINI ************************************************

    //Objetos Primarios=
    //Personales:
    public GameObject playerCamera1;
    private Rigidbody2D rb;
    public ChangeStatesPlayer1 changeStates;
    public GameObject body;
    public Animator anim;

    //Externos:
    public LevelManager levelManager;

    //Estados Generales=
    public bool active;

    //Movimiento=
    //A los lados:
    private float moveHorizontal; //Direccion horizontal donde se movera el jugador (solo incluye derecha o izquierda)
    private float speed; //Velocidad con que corre el jugador  
    public List<string> controlMovement;

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
            rb = GetComponent<Rigidbody2D>();
        }

        //Movimiento=
        {
            speed = 20;
            controlMovement.Add ("a"); //0
            controlMovement.Add ("d"); //1
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
                if (Input.GetKey(controlMovement[0]) && !Input.GetKey(controlMovement[1]) || Input.GetKey(controlMovement[1]) && !Input.GetKey(controlMovement[0]))
                {
                    //anim.SetBool("Idle", false);
                    //anim.SetBool("Run", true);
                    moveHorizontal = Input.GetAxis("Horizontal") * speed;
                    rb.AddForce(Vector2.right * moveHorizontal, ForceMode2D.Impulse);
                    if (rb.velocity.magnitude > speed)
                        ForceReduced();
                }
                else
                {
                    if (rb.velocity.magnitude > 0)
                    {
                        ForceReduced();
                        Repose();
                    }
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
    //reposo=
    private void Repose()
    {
        //anim.SetBool("Idle", true);
        //anim.SetBool("Run", false);
    }
    private void ForceReduced()
    {
        rb.AddForce(new Vector2(-rb.velocity.x, 0) * 1 * 0.2f, ForceMode2D.Impulse);
    }
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