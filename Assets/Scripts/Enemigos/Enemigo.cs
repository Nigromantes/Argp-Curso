using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {

    public Atributos atributos;
    public string nombre;
    public int experiencia;
    public GameObject Puff;

    protected void PresentarsedeFormaCortes()
    {
        Debug.Log("Hola mi nombres " + nombre);

    }

    public void EntregarExperiencia()
    {
        GameManager.instance.jugador.GetComponent<Experiencia>().experiencia += experiencia;
        Debug.Log("Se entrego la experiencia");
    }


  

}
