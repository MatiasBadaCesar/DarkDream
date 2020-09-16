
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
    private Rigidbody2D rb2d; //Rigidbody del propio jugador para poder controlar sus fisicas
    public GameObject bases;
    public Animator anim;
    private bool animIdle;
    private bool animRun;
    //Externos:
    public LevelManager levelManager;

    //Estados Generales=
    public bool active; //Esta condicion desactivara sus funciones generales y basicas (Como moverse o morir). Pero no todos sus metodos
    public bool isGrounded; //Si esta tocando el suelo
    private bool isFalling; //Si esta cayendo

    //Movimiento=
    //A los lados:
    private float moveHorizontal; //Direccion horizontal donde se movera el jugador (solo incluye derecha o izquierda)
    private float speed; //Velocidad con que corre el jugador  
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
            rb2d = GetComponent<Rigidbody2D>();
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
            //Salto:
            jumpSpeed = 160;
        }

        //Asignacion General=
        {
            //Animaciones por Defecto:
            anim.SetBool("Idle", true);
            animIdle = true;
        }
    }
    void Update()
    {
        //Si esta o no cayendo el objeto
        {
            if (rb2d.velocity.y < -0.1)
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
                //A los lados:
                {
                    moveHorizontal = Input.GetAxis("Horizontal");
                    if (Input.GetKey("left") || Input.GetKey("right") || Input.GetKey("a") || Input.GetKey("d"))
                    {
                        if (Input.GetKey("left") && Input.GetKey("right") || Input.GetKey("a") && Input.GetKey("d") || Input.GetKey("right") && Input.GetKey("a") || Input.GetKey("left") && Input.GetKey("d"))
                        {
                            if (Input.GetKey("up") || Input.GetKey("w"))
                            {

                            }
                            else
                            {
                                Repose();
                            }
                        }
                        else
                        {
                            anim.SetBool("Idle", false);
                            animIdle = false;
                            if (Input.GetKey("left") || Input.GetKey("a"))
                            {
                                transform.position += transform.right * Time.deltaTime * -speed;
                                body.transform.localScale = new Vector2(1.8f, body.transform.localScale.y);
                                anim.SetBool("Run", true);
                                animRun = true;
                            }
                            if (Input.GetKey("right") || Input.GetKey("d"))
                            {
                                transform.position += transform.right * Time.deltaTime * speed;
                                body.transform.localScale = new Vector2(-1.8f, body.transform.localScale.y);
                                anim.SetBool("Run", true);
                                animRun = true;
                            }
                        }
                    }
                    //Reposo:
                    else
                    {
                        if (Input.GetKey("up") || Input.GetKey("w"))
                        {

                        }
                        else
                        {
                            if (animRun == true)
                            {
                                Repose();
                            }
                        }
                    }
                }
                //Salto:         
                {
                    if (dontJump == false)
                    {
                        if (Input.GetKey("up") || Input.GetKey("w"))
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
        }
        else
        {
            Repose();
        }
    }

    //Secundario:
    //salto=
    private void Jump()
    {
        IsNotGrounded();
        anim.SetBool("Jump", true);
        rb2d.velocity *= 0f;
        rb2d.AddForce(Vector3.up * jumpSpeed, ForceMode2D.Impulse);
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
        rb2d.velocity *= 0f;
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
