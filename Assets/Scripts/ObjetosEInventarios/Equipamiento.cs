using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Equipo
{
    casco, armadura, arma
}

[CreateAssetMenu(menuName = "Objetos Escriptables / Items / Equipamiento")]
public class Equipamiento : Item {

    public Equipo tipoEquipamiento;
    public int salud;
    public int ataque;
    public int velocidad;

     
    public override bool UsarItem()
    {
        Equipamiento equipamientoActualmenteEquipado = PanelDeEquipamiento.instance.EquiparObjeto(this);
        Debug.Log("Se ejecuta la la primera declaracion de usar item ");

        if (equipamientoActualmenteEquipado)
        {
            Debug.Log("Se ejecuta el if de usar item");
            PanelDeEquipamiento.instance.RemoverEquipamiento(equipamientoActualmenteEquipado);
            Inventario.instance.AgregarObjeto(equipamientoActualmenteEquipado, 1);

        }


        return true;
    }


}
