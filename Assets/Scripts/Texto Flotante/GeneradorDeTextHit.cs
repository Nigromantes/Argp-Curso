using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDeTextHit : MonoBehaviour {

    public TextHit textHit;
    public Rango rangoXDefault = new Rango() ;  
    public Rango rangoYDefault = new Rango() ;  

    

    public void CrearTextoHit(TextHit texthit,string contenido,Transform parent, float tamanio,Color color,
        Rango rangoX, Rango rangoY,float tiempoDeVida)
    {
        Vector3 desfase = new Vector2(Random.Range(rangoX.min, rangoX.max), Random.Range(rangoY.min, rangoY.max));
        TextHit nuevoTexto = Instantiate(texthit, parent.position+desfase, Quaternion.identity, parent);
        nuevoTexto.tiempoDeVida = tiempoDeVida;
        nuevoTexto.color = color;
        nuevoTexto.textMesh.characterSize= tamanio;
        nuevoTexto.textMesh.text = contenido;

         
    }

    public void CrearTextoHit(TextHit texthit, float contenido, Transform parent, float tamanio, Color color,
        Rango rangoX, Rango rangoY, float tiempoDeVida)
    {
        string contenidoString = contenido.ToString();
        CrearTextoHit(texthit, contenidoString, parent, tamanio, color, rangoX, rangoY, tiempoDeVida);
        
    }
       

    public void CrearTextoHit(TextHit texthit, float contenido, Transform parent, float tamanio, Color color, float tiempoDeVida)
    {
       CrearTextoHit(texthit, contenido, parent, tamanio, color, rangoXDefault, rangoYDefault, tiempoDeVida);
    }
    
    public void CrearTextoHit(string contenido)
    {

        CrearTextoHit(textHit, contenido, transform, 0.25f, Color.white, rangoXDefault, rangoYDefault, 2f);

    }

    public void CrearTextoHit(float contenido, Transform parent)
    {
        CrearTextoHit(textHit, contenido, parent, 0.2f, Color.white, rangoXDefault, rangoYDefault, 2f);
    }


}
