using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : Interactivo {

    public string DialogoId;
   
    public void Hablar()
    {

        VentanaDeDialogo.instance.IniciarDialogo(GestorDialogo.instance.dialogosDic[DialogoId]);

      
       
    }

    
}
