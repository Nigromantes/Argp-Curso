using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonAtributo: MonoBehaviour {


    public void ActivarODesactivarBotonAtributos(int puntosDeAtributos)
    {
        if (puntosDeAtributos >0)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
