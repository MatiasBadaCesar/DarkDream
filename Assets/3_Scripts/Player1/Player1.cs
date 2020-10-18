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
    public AudioSource audioHabilidad;

    //Externos:
    public LevelManager levelManager;

    //Estados Generales=
    public bool active;
    private float bodyx;

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
            speed = 15;
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
                Active();
            //Valor scala X body:
            bodyx = body.transform.localScale.x;
        }

    }
    void FixedUpdate()
    {
        if (active == true)
        {
            //Movimiento=
            {
                if (Input.GetKey(controlMovement[0]) && !Input.GetKey(controlMovement[1]) || Input.GetKey(controlMovement[1]) && !Input.GetKey(controlMovement[0]))
                {
                    anim.SetBool("Run", true);
                    moveHorizontal = Input.GetAxis("Horizontal") * speed;
                    rb.AddForce(Vector2.right * moveHorizontal, ForceMode2D.Impulse);
                    if (rb.velocity.magnitude > speed)
                        ForceReduced();
                    //Animacion:
                    if (moveHorizontal > 0)
                    {
                        body.transform.localScale = new Vector2(bodyx, body.transform.localScale.y);
                    }
                    if (moveHorizontal < 0)
                    {
                        body.transform.localScale = new Vector2(-bodyx, body.transform.localScale.y);
                    }
                }
                else
                {
                    if (rb.velocity.magnitude > 0 || anim.GetBool ("Run"))
                    {
                        ForceReduced();
                        Repose();
                    }
                }
            }

            //Habilidad= 
            {
                if (Input.GetKey("w"))
                {
                    if (keyUp == true)
                    {
                        keyUp = false;
                        Skill();
                    }
                }
                else
                {
                    if (keyUp == false)
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
        audioHabilidad.Play();
    }

    //Terciario:
    //reposo=
    private void Repose()
    {
        anim.SetBool("Run", false);
    }
    private void ForceReduced()
    {
        rb.AddForce(new Vector2(-rb.velocity.x, 0) * 1 * 0.2f, ForceMode2D.Impulse);
    }
    //muerte=
    private void Dead()
    {
        active = false;
        Repose();
        rb.velocity = Vector2.zero;
        anim.SetBool("Dead", true);
    }
    public void ResetLevel()
    {
        levelManager.Restart();
    }

    //collider=
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().tag == "Enemy")
        {
            Dead();
        }
    }

}