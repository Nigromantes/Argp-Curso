using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hechicero : EnemigoIA {

    public Proyectil proyectil;

    public override void EnemigoAtacar()
    {
        habilidad.DispararProyectil(proyectil, proyectil.velocidadInicial, input.direccionHaciaJugador, proyectil.danio);
        //Debug.Log("Estoy atacando");
    }

    protected override void VoltearSprite()
    {
        if (input.horizontal < 0)
        {
            spriteRender.flipX = false;
        }
        else
        {
            spriteRender.flipX = true ;
        }

    }
}
