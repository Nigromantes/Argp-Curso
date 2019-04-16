using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasillaEquipamento : Casilla {

    public Equipo tipoEquipamiento;

    protected override void UsarObjetoEnCasilla() 
    {
        DesequiparObjeto();
    }

    private void DesequiparObjeto()
    {
        Debug.Log("Se ejecuta 'desequierpar objeto' ");
        if(Inventario.instance.AgregarObjeto(itemAlmacenado, 1))
        {
            
            EliminarObjeto(); 
        }
    }

    public override void EliminarObjeto()
    {
        PanelDeEquipamiento.instance.RemoverEquipamiento((Equipamiento)itemAlmacenado);
        ResetarCasilla();
    }
}
