﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEnemigo : MonoBehaviour {

    public Transform jugador;
    public float vertical  {
        get
        {
            return direccionHaciaJugador.y;
        }
     }
    public float horizontal
    {
        get
        {
            return direccionHaciaJugador.x;
        }
    }
    public float distanciaJugador
    {
        get { return direccionHaciaJugador.magnitude; }
    }
    public Vector2 direccionHaciaJugador { get; private set; } 



    // Use this for initialization
    void Start ()
    {
        //jugador = GameManager.instance.jugador.transform;
        DefinirDireccionHaciaEljugador();

    }

   // Update is called once per frame
    void Update()
    {

        DefinirDireccionHaciaEljugador();

    }

    private void DefinirDireccionHaciaEljugador()
    {
        direccionHaciaJugador = jugador.position - transform.position;
    }

}
