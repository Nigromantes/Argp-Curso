using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atacante : MonoBehaviour {

    public float desfase = 1f;
    public Vector2 hitBox = new Vector2(1, 1);
    private Vector2 vectorDesfaseAtaque;
    private Vector2 puntoA, puntoB;
    public LayerMask LayerAtaque;
    private Collider2D[] AtaqueColliders = new Collider2D[12];
    private ContactFilter2D FiltroAtaque;
    public GameObject destello;
    private GeneradorDeTextHit generadorDeTextHit;

    public AudioClip audioClip;
    private AudioSource audioSource;

    private void Start()
    {
        FiltroAtaque.layerMask = LayerAtaque;
        FiltroAtaque.useLayerMask = true;
        generadorDeTextHit = GetComponent<GeneradorDeTextHit>();

        audioSource = GetComponent<AudioSource>();
    }



    private void Update()
    {
        Debug.DrawLine(transform.position, (Vector2)transform.position + vectorDesfaseAtaque, Color.yellow);
        Debug.DrawLine(puntoA, puntoB, Color.red);
    }

    
    public void Atacar(Vector2 direccionDeAtaque, int danio)
    {
        CrearHitBox(direccionDeAtaque);
        GameObject objetoAtacado;
        int elementosAtacados=  Physics2D.OverlapArea(puntoA, puntoB, FiltroAtaque, AtaqueColliders);
        //Debug.Log("Se ejecuta el audio");

        audioSource.clip = audioClip;
        audioSource.Play();
      


        for (int i = 0; i < elementosAtacados; i++)
        {
            objetoAtacado = AtaqueColliders[i].gameObject;

            if (objetoAtacado.GetComponent<Atacable>())
            {
                objetoAtacado.GetComponent<Atacable>().RecibirAtaque(direccionDeAtaque, danio);
                InvocarDestello(objetoAtacado);
                GenerarTextoHit(danio, objetoAtacado);

            }



        }

        
    }

    private void GenerarTextoHit(int danio, GameObject objetoAtacado)
    {
        if (generadorDeTextHit)
        {
            //generadorDeTextHit.CrearTextoHit(generadorDeTextHit.textHit, danio, objetoAtacado.transform, 0.2f, Color.white, generadorDeTextHit.rangoXDefault,
            //generadorDeTextHit.rangoYDefault, 2f);

            generadorDeTextHit.CrearTextoHit(danio, objetoAtacado.transform);
        }
    }

    private void InvocarDestello(GameObject objetoAtacado)
    {
        if (destello != null)
        {
            Instantiate(destello, objetoAtacado.transform);

        }
    }

    private void CrearHitBox(Vector2 direccionDeAtaque)
    {
        Vector2 escala = transform.lossyScale;
        Vector2 HitBoxEscalado = Vector2.Scale(hitBox, escala);
       // Debug.Log("Estoy Atacando");
        vectorDesfaseAtaque = Vector2.Scale(direccionDeAtaque.normalized * desfase, escala);
        puntoA = (Vector2)transform.position + vectorDesfaseAtaque - HitBoxEscalado * 0.5f;
        puntoB = puntoA + HitBoxEscalado;
    }
}
