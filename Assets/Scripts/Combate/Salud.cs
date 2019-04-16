using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Salud : MonoBehaviour {



    public int saludBase;
    private int saludActual;

    public int salud { get { return saludBase + modificadorSalud; } }

    public UnityEvent OnMorir;

    public Image barraDeSalud;
    public int modificadorSalud;




    public int SaludActual {

        get
        {
            return saludActual;
        }

        set
        {
            if (value > 0 && value <= salud)
            {
                saludActual = value;
            }
            else if (value > salud)
            {
                saludActual = salud;
            }
            else
            {
                saludActual = 0;

                gameObject.layer = 12;
                if (OnMorir != null)
                {
                    OnMorir.Invoke();
                   // Debug.Log("Se invoco");
                }
            }
        }

    }

    

    // Use this for initialization
    void Start()
    {
        SaludActual = salud;
	}

    public void ModificarSaludActual(int cantidad)
    {
        SaludActual += cantidad;
        ActualizarBarraDeSalud();
    }

    private void DestruirGameObject()
    {
        Destroy(gameObject);
    }

    public void ActualizarBarraDeSalud()
    {
        if (barraDeSalud)
        { 
        barraDeSalud.fillAmount = (float)SaludActual / salud;
        }
    }

    public void ModificarSaludBase(int cantidad)
    {
        saludBase += cantidad;
        ActualizarBarraDeSalud();
    }
}
