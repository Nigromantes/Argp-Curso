using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelDeEquipamiento : MonoBehaviour {

    public static PanelDeEquipamiento instance;
    public Atributos atributos;
    public CasillaEquipamento[] casillaEquipamentos;
    public List<Equipamiento> equipamientos = new List<Equipamiento>();


    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {

        casillaEquipamentos = GetComponentsInChildren<CasillaEquipamento>();

		
	}

    public Equipamiento EquiparObjeto(Equipamiento equipamiento)
    {
       // Debug.Log("Se ejecuta 'Equipar objeto'");
        foreach ( CasillaEquipamento casillaEquipo in casillaEquipamentos)
        {
           // Debug.Log("Se inicia el 'foreach'");
            if (equipamiento.tipoEquipamiento == casillaEquipo.tipoEquipamiento)
            {
                //Debug.Log("Se inicia el primer 'if'");
                if (!casillaEquipo.itemAlmacenado)
                {

                   // Debug.Log("Casilla está vacía");
                    AgregarEquipo(equipamiento, casillaEquipo);
                    return null;
                
                }
                else
                {
                    Equipamiento objetoEquipado = casillaEquipo.itemAlmacenado as Equipamiento;
                    AgregarEquipo(equipamiento, casillaEquipo);
                    return objetoEquipado;
                }
            }
           
        }
        return null;

    }

    private void AgregarEquipo(Equipamiento equipamiento, CasillaEquipamento casillaEquipo)
    {
        Debug.Log("Se ejecuta 'Agregar equipo'");
        casillaEquipo.AgregarObjeto(equipamiento, 1);
        equipamientos.Add(equipamiento);
        atributos.ActualizarEquipamiento(equipamientos);
    }

    public void RemoverEquipamiento(Equipamiento equipamiento)
    {
        equipamientos.Remove(equipamiento);
        atributos.ActualizarEquipamiento(equipamientos);

    }
}
