using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour {

    public bool inventarioLleno;
    public static Inventario instance;
    private Casilla[] casillas;
    private List<Item> objetos = new List<Item>();
    private int casillaVacia = 0;

    private void Awake()
    {
        instance = this;
        casillas = GetComponentsInChildren<Casilla>();
    }

    private void DeterminarSiguienteCasillaVacia()
    {
        casillaVacia = 0;
        foreach (Casilla casilla in casillas)
        {
            if (casilla.itemAlmacenado)
            {
                casillaVacia++;
            }
            else
            {
                break;
            }
        }
        if (casillaVacia >= casillas.Length)
        {
            inventarioLleno = true;
        }


    }

    public bool AgregarObjeto  (Item item, int cantidad)
    {
        DeterminarSiguienteCasillaVacia();
      
        if ((item.apilable && !objetos.Contains(item) && !inventarioLleno) || (!item.apilable && !inventarioLleno))
        {
            //Nuestro objeto es apilable y no tenemos copia de él en nuestro inventario. 

            Casilla casillaANadir = casillas[casillaVacia];
            objetos.Add(item);
            casillaANadir.AgregarObjeto(item, cantidad);
            return true;
        }
        else if (item.apilable && objetos.Contains(item))
        {
            //Nuestro objeto es apilable y tenemos una copia de él en el inventario. 
            for (int i = 0; i < casillas.Length; i++)
            {
                if (item == casillas[i].itemAlmacenado)
                {
                    casillas[i].CantidadStock += cantidad;
                    break;

                }
              
            }
            return true;


        }
        else
        {
            Debug.Log("Inventario lleno");
            return false;

        }
        //return true;
    }

    public void RemoverObjeto(Item item)
    {
        objetos.Remove(item);
    }
}
