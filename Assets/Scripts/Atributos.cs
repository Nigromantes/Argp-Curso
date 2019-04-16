using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Atributo
{
    velocidad,
    ataque,
    salud, 

}

[CreateAssetMenu(menuName = "Objetos Escriptables / Atributos")]
public class Atributos : ScriptableObject {

    [SerializeField]
    private int velocidadBase;
    [SerializeField]
    private int ataqueBase;
    private int ataqueModificador;
    private int velocidadModificador;
     
    public int velocidad  { get { return velocidadBase + velocidadModificador; } }
    public int ataque  { get { return ataqueBase + ataqueModificador; } }

    public void AumentarVelocidadBase(int cantidad)
    {
        velocidadBase += cantidad;

    }

    public void AumentarAtaqueBase(int cantidad)
    {
        ataqueBase += cantidad;

    }

    public void ModificarAtributo(Atributo atributo, int cantidad)
    {
        switch (atributo)
        {

            case Atributo.velocidad:
                velocidadModificador += cantidad;
                break;
            case Atributo.ataque:
                ataqueModificador += cantidad;
                break;
            case Atributo.salud:
                break;
            default:
                break;
        }

    }

    public void ModificadorSalud(Salud salud, int cantidad)
    {
        salud.modificadorSalud += cantidad;
    }

    public void ActualizarEquipamiento(List<Equipamiento> equipamientos)
    {
        ResetearModificadores();
        foreach (Equipamiento equipo in equipamientos)
        {
            velocidadModificador += equipo.velocidad;
            ataqueModificador += equipo.ataque;

            GameManager.instance.jugador.GetComponent<Salud>().modificadorSalud += equipo.salud;
        }
        PanelAtributos.instance.ActualizarTextosAtributos(this, GameManager.instance.jugador.GetComponent<Salud>(), 
                GameManager.instance.jugador.GetComponent<Experiencia>());
        
        GameManager.instance.jugador.GetComponent<Salud>().ActualizarBarraDeSalud();
    }

    private void ResetearModificadores()
    {
        velocidadModificador = 0;
        ataqueModificador = 0;

        GameManager.instance.jugador.GetComponent<Salud>().modificadorSalud = 0;
    }
}
