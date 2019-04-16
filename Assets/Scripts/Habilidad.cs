using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habilidad : MonoBehaviour {

	

    public void DispararProyectil(Proyectil proyectil, float velocidadInicial, Vector2 direccion, int danio)
    {
        Proyectil nuevoProyectil = Instantiate(proyectil,transform.position,Quaternion.identity);
        //nuevoProyectil.gameObject.transform.SetParent(transform);
        nuevoProyectil.gameObject.transform.SetParent(GameManager.instance.contendorDeProyectiles);

        float anguloRotacion = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
        nuevoProyectil.transform.Rotate(0, 0, anguloRotacion);

        nuevoProyectil.velocidadInicial = velocidadInicial;
        nuevoProyectil.direccionInicial = direccion;
        nuevoProyectil.danio = danio;

       

    }

    public void Dash(Vector2 DireccionDash, Rigidbody2D rigidBody)
    {
        Vector2 direcccionVelocidad = DireccionDash.normalized * 20;
        rigidBody.velocity = direcccionVelocidad;
    }
}
