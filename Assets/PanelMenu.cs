﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelMenu : MonoBehaviour {

	public static PanelMenu instance { get; private set; }
    private CanvasGroup canvasGroup;
    private bool abierto;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }

    }




    private void Start()
    {
        

        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void AbrirCerrarPaneles()
    {
        if (abierto)

        {
            CerrarPaneles();
           
        }
        else
        {
            AbrirPaneles();
            ;
        }


    }

    private void AbrirPaneles()
    {
        abierto = true;
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        Time.timeScale = 0;       
    }

    private void CerrarPaneles()
    {

        abierto = false;
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        Time.timeScale = 1;

    }
}
