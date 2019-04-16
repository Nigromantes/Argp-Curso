using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    //Movimiento del personaje. 
    private InputPlayer inputJugador;
    //private Transform transformada;
    private Rigidbody2D miRigidBody2d;
    public float horizontal;
    public float vertical;
    public Atributos atributosJugador;

    //Animación
    private Animator animator;
    private SpriteRenderer miSprite;

    /*Esta variable será para usar un Hash code, 
    es un método que hará que el string de la 
    variable animator sea un int. */

    int corrertHashCode;

    //Atributos. 
    private Experiencia experiencia;
    private Salud salud;

    //Clase Atacante
    private Atacante atacante;

    //interacción efectos y otros. 
    public LayerMask layerInteraccion;
    public TrailRenderer trailRenderer;
    public Proyectil proyectil;
    private Habilidad habilidad;
    private float dashCoolDown;
    private bool usandoDash;

    //Sonido. 
    private SonidoPisadas sonidoPisadas;
       
    // Use this for initialization
    void Start()
    {
        //Movimiento
        inputJugador = GetComponent<InputPlayer>();
        //transformada = GetComponent<Transform>();
        miRigidBody2d = GetComponent<Rigidbody2D>();
             
        //Animación
        animator = GetComponent<Animator>();
        miSprite = GetComponent<SpriteRenderer>();
        corrertHashCode = Animator.StringToHash("Corriendo");

        //interacción
        atacante = GetComponent<Atacante>();
        
        //Atributos. 
        salud = GetComponent<Salud>();
        experiencia = GetComponent<Experiencia>();        
        PanelAtributos.instance.ActualizarTextosAtributos(atributosJugador, salud, experiencia);

        //Otros. 
        habilidad = GetComponent<Habilidad>();
        trailRenderer = GetComponent<TrailRenderer>();
        sonidoPisadas = GetComponentInChildren<SonidoPisadas>();
               
    }


    // Update is called once per frame
    void Update()
    {

        //Animación. 
        horizontal = inputJugador.ejeHorizontal;
        vertical = inputJugador.ejeVertical;


        if (vertical != 0 || horizontal != 0)
        {
            SetXYAnimator();
            animator.SetBool(corrertHashCode, true);

        }
        else
        {
            animator.SetBool(corrertHashCode, false);

        }

        //Ataque. 
        if (inputJugador.atacar)
        {
            //Debug.Log("Se sejecuta el ataque");

            ControllerAtacar();

        }

        //Inventario. 
        if (inputJugador.inventario)
        {
            PanelMenu.instance.AbrirCerrarPaneles();

        }

        //Habilidades. 
        ActualizarCoolDownDash();

    }


    private void ActualizarCoolDownDash()
    {

        if (usandoDash)
        {
            dashCoolDown += Time.deltaTime;
            if (dashCoolDown > trailRenderer.time)
            {
                ActivaroDeasctivarTrailRender();
                dashCoolDown = 0;
                usandoDash = false;
            }
        }
    }


    //Animación. 
    private void SetXYAnimator()
    {
        animator.SetFloat("X", horizontal);
        animator.SetFloat("Y", vertical);
    }

    //Movimiento. 
    void FixedUpdate() {

        //Ataque - movimiento y animación. 
        if (animator.GetBool("Atacando"))
        {

            miRigidBody2d.velocity = Vector2.zero;
        }
        else if ((vertical != 0 || horizontal != 0) && !usandoDash)
        {
            //-----Movimiento----//
            Vector2 vectorVelocidad = new Vector2(horizontal, vertical) * atributosJugador.velocidad /* Time.deltaTime*/;
            miRigidBody2d.velocity = vectorVelocidad;

        }

        //---Habilidades---//

        //Dash 
        if (inputJugador.habilidad2)
        {
            usandoDash = true;
            //Debug.Log("SE presiona habilidad2");
            habilidad.Dash(inputJugador.direccionMirada, miRigidBody2d);
            ActivaroDeasctivarTrailRender();

        }

        //Proyectil. 
        if (inputJugador.habilidad1)
        {
            habilidad.DispararProyectil(proyectil, 10, inputJugador.direccionMirada, atributosJugador.ataque);
        }

    }


    //Ataque 
    void ControllerAtacar()
    {
        atacante.Atacar(inputJugador.direccionMirada, atributosJugador.ataque);
        animator.SetBool("Atacando", true);
    }

    //Animación - Ataque. 
    void DesactivarAnimacionAtaque()
    {
        
        animator.SetBool("Atacando", false);
    }


    //Trail Render 
    private void ActivaroDeasctivarTrailRender()
    {
        if (trailRenderer.enabled)
        {
            trailRenderer.enabled = false;
        }
        else
        {
            trailRenderer.enabled = true;
        }
    }

    //Interacción. 
    public RaycastHit2D[] Interactuar()
    {
        RaycastHit2D[] circleCast = 
        Physics2D.CircleCastAll(transform.position, 
              GetComponent<CapsuleCollider2D>().size.x, inputJugador.direccionMirada, 2f, layerInteraccion);

        if (circleCast != null)
        {
            return circleCast;
        }
        else
        {
            return null;
        }
    }

    //Sonido. 
    public void SonidoPies()
    {
        sonidoPisadas.ReproducirSonidoPasos();
    }


}
