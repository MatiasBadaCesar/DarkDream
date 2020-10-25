
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    //ATRIVUTOS Y PROPIEDADES           ************************************************ MATIAS BADALONI CESARINI ************************************************

    //Objetos Primarios=
    //Personales:
    public GameObject playerCamera2;
    public GameObject body;
    private Rigidbody2D rb
        ; //Rigidbody del propio jugador para poder controlar sus fisicas
    public GameObject bases;
    public Animator anim;
    private bool animIdle;
    private bool animRun;
    //Externos:
    public LevelManager levelManager;

    //Estados Generales=
    public bool active; //Esta condicion desactivara sus funciones generales y basicas (Como moverse o morir). Pero no todos sus metodos
    private float bodyx;
    public bool isGrounded; //Si esta tocando el suelo
    private bool isFalling; //Si esta cayendo

    //Movimiento=
    //A los lados:
    private float moveHorizontal; //Direccion horizontal donde se movera el jugador (solo incluye derecha o izquierda)
    private float speed; //Velocidad con que corre el jugador  
    public List<string> controlMovement;
    //Salto:
    public bool dontJump;
    private float jumpSpeed; //Velocidad de impulso del salto
    private bool keyUp; //si fue o no precionada                      

    //METODOS PRIMARIOS //           ************************************************ MATIAS BADALONI CESARINI ************************************************

    //Activar=
    public void Active()
    {
        active = true;
        playerCamera2.SetActive(true);
    }
    public void Desactive()
    {
        active = false;
        playerCamera2.SetActive(false);
    }

    //General=
    //Principal:
    void Start()
    {
        //Objetos Primarios=
        {
            rb = GetComponent<Rigidbody2D>();
            anim = bases.GetComponent<Animator>();
        }

        //Estados Generales=
        {
            isGrounded = true;
        }

        //Movimiento=
        {
            //A los lados:
            speed=40;
            controlMovement.Add("a"); //0
            controlMovement.Add("d"); //1
            //Salto:
            jumpSpeed = 160;
        }

        //Asignacion General=
        {
            //Valor scala X body:
            bodyx = body.transform.localScale.x;
            //Animaciones por Defecto:
            anim.SetBool("Idle", true);
            animIdle = true;
        }
    }
    void Update()
    {
        //Si esta o no cayendo el objeto
        {
            if (rb.velocity.y < -0.1)
            {
                IsFalling();
            }
            else
            {
                IsNotFalling();
            }
        }

        if (active == true)
        {
            //Movimiento=
            {
                if (Input.GetKey(controlMovement[0]) && !Input.GetKey(controlMovement[1]) || Input.GetKey(controlMovement[1]) && !Input.GetKey(controlMovement[0]))
                {
                    moveHorizontal = Input.GetAxis("Horizontal") * speed;
                    rb.AddForce(Vector2.right * moveHorizontal, ForceMode2D.Impulse);
                    if (rb.velocity.magnitude > speed)
                        ForceReduced();

                    //Animacion:
                    anim.SetBool("Idle", false);
                    anim.SetBool("Run", true);
                    animIdle = false;
                    animRun = true;
                    if (moveHorizontal < 0)
                    {
                        body.transform.localScale = new Vector2(1.8f, body.transform.localScale.y);
                    }
                    if (moveHorizontal > 0)
                    {
                        body.transform.localScale = new Vector2(-1.8f, body.transform.localScale.y);
                    }
                    if (rb.velocity.magnitude > 0 || anim.GetBool("Run") || isGrounded == false)
                    {
                        ForceReduced();
                    }
                }
                else
                {
                    if (rb.velocity.magnitude > 0 || anim.GetBool("Run") || isGrounded == false)
                    {
                        ForceReduced();
                        Repose();
                    }
                }
            }

            //Salto:         
            {
                if (dontJump == false)
                {
                    if (Input.GetKey("w"))
                    {
                        if (keyUp == false)
                        {
                            keyUp = true;
                            //saltar=
                            if (isGrounded == true)
                            {
                                Jump(); //salto  
                            }
                        }
                    }
                    else
                    {
                        keyUp = false;
                    }
                }
            }
        }
        else
        {
            if (rb.velocity.magnitude > 0 || anim.GetBool("Run"))
            {
                ForceReduced();
                Repose();
            }
        }
    }

    //Secundario:
    //salto=
    private void Jump()
    {
        IsNotGrounded();
        anim.SetBool("Jump", true);
        rb.velocity *= 0f;
        rb.AddForce(Vector3.up * jumpSpeed, ForceMode2D.Impulse);
    }
    //caida=
    private void IsFalling()
    {
        isFalling = true;
        anim.SetBool("Fall", true);
    }
    private void IsNotFalling()
    {
        isFalling = false;
        anim.SetBool("Fall", false);
    }
    //suspendido=
    public void IsGrounded()
    {
        rb.velocity *= 0f;
        isGrounded = true;
        anim.SetBool("NotGround", false);
        anim.SetBool("Jump", false);
    }
    public void IsNotGrounded()
    {
        isGrounded = false;
        anim.SetBool("NotGround", true);
    }

    //Terciario:
    //reposo=
    private void Repose()
    {
        if (animRun == true && body.transform.localScale.x== 1.8f)
        {
            body.transform.localScale = new Vector2(1.8f, body.transform.localScale.y);
            anim.SetBool("Run", false);
            animRun = false;
            anim.SetBool("Idle", true);
            animIdle = true;
        }
        if (animRun == true && body.transform.localScale.x == -1.8f)
        {
            body.transform.localScale = new Vector2(-1.8f, body.transform.localScale.y);
            anim.SetBool("Run", false);
            animRun = false;
            anim.SetBool("Idle", true);
            animIdle = true;
        }
    }
    private void ForceReduced()
    {
        rb.AddForce(new Vector2(-rb.velocity.x, 0) * 1 * 0.2f, ForceMode2D.Impulse);
    }
    //muerto=
    public void Dead()
    {
        /*    
            anim.SetBool("Alive", false);
            anim.SetBool("MoveRight", false);
            anim.SetBool("MoveLeft", false);
            anim.SetBool("Shield", false);
            anim.SetBool("Death", true);
        */
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
