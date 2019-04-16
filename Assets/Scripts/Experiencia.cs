using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Experiencia : MonoBehaviour {

    private PlayerController player;
    private Salud salud;

    public BotonAtributo[] botonesAtributos;

    public Image BarraDeExp;

    private GeneradorDeTextHit generadorText;
    private Rango rangoLeveUp = new Rango() { min = 0, max = 0 };

    private int experienciaActual;
    private int expSiguienteNivel;//Exp necesaria para subir al siguiente nivel. 

    private float razonExpNivelActual;//Será % necesario para subir de nivel. 
    public int puntosDeAtributos; 
    
    public int nivel { get; set; }
    public int experiencia
    {
        get { return experienciaActual; }

        set
        {
            experienciaActual = value;

            if (nivel > 1)
            {
                razonExpNivelActual = (float)(experiencia - CurvaExperienciaAcumulativa(nivel)) / expSiguienteNivel;

                RevisarSiSeSubeNivel();
            }
            else
            {
                razonExpNivelActual = (float)(experienciaActual) / expSiguienteNivel;
                RevisarSiSeSubeNivel();
            }
            ActualizarBarraExperiencia();
            ActualizarPanelDeAtributos();

        }
    }

    private void RevisarSiSeSubeNivel()
    {
        while (razonExpNivelActual > 1)
        {
            LevelUp();
        }
    }

    // Use this for initialization

    void Awake () {
        nivel = 1;
        generadorText = GetComponent<GeneradorDeTextHit>();
        player = GetComponent<PlayerController>();
        salud = GetComponent<Salud>();

        expSiguienteNivel = CurvaExperiencia(nivel);
        ActualizarBarraExperiencia();
        LlamarBotonesAtributos();
        ActualizarPanelDeAtributos();
	}

    private int CurvaExperiencia(int nivel)
    {
        float funcionExperiencia = Mathf.Log(nivel, 3f) + 10;
        int experiencia = Mathf.CeilToInt(funcionExperiencia);

        return experiencia;
             
    }

    private int CurvaExperienciaAcumulativa(int nivel)
    {

        int experiencia = 0;

        for (int i = 1; i < nivel; i++)
        {
            experiencia += CurvaExperiencia(i);
        }
        return experiencia;


    }

    private void LevelUp()
    {

        nivel++;
        ConfiguarSiguienteNivel();
        generadorText.CrearTextoHit(generadorText.textHit, "Nuevo Nivel", transform, 0.4f, Color.cyan,rangoLeveUp,rangoLeveUp, 3f);
        razonExpNivelActual = (float)(experiencia - CurvaExperienciaAcumulativa(nivel)) / expSiguienteNivel;
        LlamarBotonesAtributos();
    }

    void ConfiguarSiguienteNivel()

    {
        puntosDeAtributos++;
        expSiguienteNivel = CurvaExperiencia(nivel);
    }

    private void ActualizarBarraExperiencia()
    {
        if (BarraDeExp)
        {
            BarraDeExp.fillAmount = razonExpNivelActual;
        }
        
    }

    public void RestarPuntosAtributos()
    {
        puntosDeAtributos--;
        LlamarBotonesAtributos();
        ActualizarPanelDeAtributos();

    }

    public void LlamarBotonesAtributos()
    {
        for (int boton = 0; boton < botonesAtributos.Length; boton++)
        {
            botonesAtributos[boton].ActivarODesactivarBotonAtributos(puntosDeAtributos);
        }

        //foreach (var item in botonesAtributos)
        //{
        //    item.ActivarODesactivarBotonAtributos(puntosDeAtributos);
        //}
    }

    private void ActualizarPanelDeAtributos()
    {
        PanelAtributos.instance.ActualizarTextosAtributos(player.atributosJugador,salud, this);
    }
}
