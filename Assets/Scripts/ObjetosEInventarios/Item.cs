using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Objetos Escriptables / Items / ItemGenerico")]
public class Item : ScriptableObject {

    public Sprite sprite;
    public string nombre;
    public bool apilable; //Indica si se guadará más de uno? Como consumibles - tipo posiones. 
    [TextArea(1, 3)]
    public string descripcion;

    public virtual bool UsarItem()
    {
        Debug.Log("Utizando: " + nombre);
        return true; 
    }
}
