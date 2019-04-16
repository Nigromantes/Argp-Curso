using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Salud))]
[RequireComponent(typeof(InputEnemigo))]
public class EnemigoIA : Enemigo {

   
    protected InputEnemigo input;
    protected Habilidad habilidad;
    private Atacante atacante;
    protected SpriteRenderer spriteRender;

    private bool muerto;
    private bool atacando;
    private bool enCombate;
    private Animator animator;
    private Vector2 direccionDeAtaque;

    private int CorrerHash;
    private int AtacarHash;
    private int MuerteHash;


    [SerializeField] private float distanciaDeteccion;
    [SerializeField] private float distanciaAtaque;

    private void Start()
    {

        habilidad = GetComponent<Habilidad>();
        spriteRender = GetComponent<SpriteRenderer>();
        input = GetComponent<InputEnemigo>();
        atacante = GetComponent<Atacante>();
        animator = GetComponent<Animator>();

        CorrerHash = Animator.StringToHash("Corriendo");
        AtacarHash = Animator.StringToHash("Atacar");
        MuerteHash = Animator.StringToHash("Muerto");

        Instantiate(Puff, transform);

        //PresentarsedeFormaCortes();
    }

    private void Update()
    {

        Comportamiento();
    }


    protected void Comportamiento()
    {
        if (!muerto)
        {
            //Ataque
            if (!atacando && input.distanciaJugador < distanciaAtaque)
            {
                RealizarAtaque();

            }
            else if (!atacando && (enCombate || input.distanciaJugador < distanciaDeteccion))
            {
                MoverHaciaJugador();
            }
        }

    }

    private void RealizarAtaque()
    {
        int probabilidadDeAtaque = Random.Range(0, 100);

        animator.SetBool(CorrerHash, false);

        if (probabilidadDeAtaque > 95)
        {
            direccionDeAtaque = input.direccionHaciaJugador;
            atacando = true;
            enCombate = true;

            animator.SetTrigger(AtacarHash);
        }

    }

    private void MoverHaciaJugador()
    {
        animator.SetBool(CorrerHash, true);
        VoltearSprite();
        transform.position += (Vector3)input.direccionHaciaJugador * atributos.velocidad * Time.deltaTime;
    }

    public virtual void EnemigoAtacar()
    {
        atacante.Atacar(direccionDeAtaque, atributos.ataque);
        atacando = false;

    }

    protected virtual void VoltearSprite()
    {
        if (input.horizontal < 0)
        {
            spriteRender.flipX = true;
        }
        else
        {
            spriteRender.flipX = false;
        }

    }

    void SetAtacarFalse()
    {
        atacando = false;
    }

    public void Morir()
    {
        muerto = true;
        animator.SetBool(MuerteHash, true);
    }
}
