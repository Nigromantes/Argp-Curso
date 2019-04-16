using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Interactivo : MonoBehaviour,IPointerDownHandler{


    protected BoxCollider2D miCollider;
    public GestorDeNiveles miGestordeNiveles;
    public UnityEvent OnInteraction;
    protected PlayerController player;
        
    // Use this for initialization
	void Start () {

        miCollider = GetComponent<BoxCollider2D>();
        player = GameManager.instance.jugador.GetComponent<PlayerController>();		
	}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    // miGestordeNiveles.CargarSiguienteNivel(); 
    //    OnInteraction.Invoke();
    //}

    public void OnPointerDown(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
       //Debug.Log("Se está haciendo click");
        Interactuar();
    }

    private void Interactuar()
    {
        //Debug.Log("interactuar");
        foreach (RaycastHit2D interactivo in player.Interactuar() )
        {
            if (interactivo.collider.gameObject == gameObject)
            {
                Interaccion();
            }
                        
        }

    }

    public virtual void Interaccion()
    {

        //Debug.Log("Interaccion");
        OnInteraction?.Invoke();
    }

}
