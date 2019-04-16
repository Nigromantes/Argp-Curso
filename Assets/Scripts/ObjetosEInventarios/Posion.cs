using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Objetos Escriptables / Items / Posiones/Salud")]
public class Posion : Item {

    public int curacion;

    public override bool UsarItem()
    {
        Salud saludJugador = GameManager.instance.jugador.GetComponent<Salud>();

        if (saludJugador.SaludActual>=saludJugador.salud )
        {
            Debug.Log("Salud llena");
            return false;
        }
        else
        {
            saludJugador.ModificarSaludActual(curacion);
            return true;
        }
    }


}
