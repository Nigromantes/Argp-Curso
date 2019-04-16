using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class GestorDialogo : MonoBehaviour {

    public static GestorDialogo instance;

    public Dictionary<string, Dialogo> dialogosDic = new Dictionary<string, Dialogo>();

    private void Awake()
    {
        instance = this;


        Inicializar();
    }

    // Use this for initialization
    //void Start () {

        //Inicializar();
        //Dialogo prueba = dialogosDic["prueba"];
        //foreach (string linea in prueba.lineas)
        //{
        //    print(linea);
        //}

        //XmlSerilializador.Serializar<Dialogo>("dialogo.xml", prueba);

        //Dialogo dialogo0 = new Dialogo() { lineas = new string[] { "001", "002", "003" }, id = "0" };
        //Dialogo dialogo1 = new Dialogo() { lineas = new string[] { "101", "102", "103" }, id = "1" };
        //Dialogo dialogo2 = new Dialogo() { lineas = new string[] { "201", "202", "203" }, id = "2" };

        //Dialogo[] dialogos = new Dialogo[3];

        //dialogos[0] = dialogo0;
        //dialogos[1] = dialogo1;
        //dialogos[2] = dialogo2;

        //XmlSerilializador.Serializar<Dialogo[]>("dialogosEsp", dialogos);




        //Dialogo dialogoPrueba = XmlSerilializador.Deserializar<Dialogo>("dialogo.xml");



        //foreach (string lineas in dialogoPrueba.lineas)
        //{
        //    print(lineas);
        //}

   // }

    public void Inicializar()
    {
        Dialogo[] dialogos = XmlSerilializador.Deserializar<Dialogo[]>("dialogosEsp.xml");
        foreach (Dialogo dialogo in dialogos)
        {
            dialogosDic[dialogo.id] = dialogo;
        }

       
    }
	
}
