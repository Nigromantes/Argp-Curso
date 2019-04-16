using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PanelAtributos : MonoBehaviour {

    public TextMeshProUGUI txtNivel;
    public TextMeshProUGUI txtExperiencia;
    public TextMeshProUGUI txtSalud;
    public TextMeshProUGUI txtAtaque;
    public TextMeshProUGUI txtVelocidad;
    public TextMeshProUGUI txtPuntosDeAtributos;

    public static PanelAtributos instance;

    private void Awake ()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    public void ActualizarTextosAtributos(Atributos atributos, Salud salud, Experiencia experiencia)
    {
        txtNivel.text = experiencia.nivel.ToString();
        txtExperiencia.text = experiencia.experiencia.ToString();
        txtSalud.text = salud.salud.ToString();
        txtAtaque.text = atributos.ataque.ToString();
        txtVelocidad.text = atributos.velocidad.ToString();
        txtPuntosDeAtributos.text = experiencia.puntosDeAtributos.ToString();

    }
}
