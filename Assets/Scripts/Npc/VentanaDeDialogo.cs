using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class VentanaDeDialogo : MonoBehaviour {

    public static VentanaDeDialogo instance;
    public TextMeshProUGUI textMeshPro;
    public UnityEvent OnIniciarDialogo;
    public UnityEvent OnTerminarDialogo;
    private Dialogo dialogoActual;
    private int indiceLinea;

    private void Awake()
    {
        instance = this;
    }

    public void IniciarDialogo(Dialogo dialogo)
    {
        //print("ejecuta iniciar Dialogo");
        OnIniciarDialogo?.Invoke();
        dialogoActual = dialogo;
        indiceLinea = 0;
        textMeshPro.text = dialogoActual.lineas[indiceLinea];
    }

    public void SiguienteLinea()
    {
        print("Se ejecuta siguiente Linea");
        indiceLinea++;
        if (dialogoActual.lineas.Length<=indiceLinea)
        {
            OnTerminarDialogo?.Invoke();
            return;
        }
        textMeshPro.text = dialogoActual.lineas[indiceLinea];
    }
}
