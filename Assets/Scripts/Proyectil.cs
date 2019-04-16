using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class Proyectil : MonoBehaviour {

    public float velocidadInicial;
    public Vector2 direccionInicial;
    public int danio;
    public string tagObjetivo;

    private Rigidbody2D miRigidBody;
    
    // Use this for initialization
    void Start () {
        miRigidBody = GetComponent<Rigidbody2D>();
        miRigidBody.velocity = direccionInicial.normalized * velocidadInicial;
        Destroy(gameObject, 5f);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagObjetivo))
        {
            collision.gameObject.GetComponent<Atacable>().RecibirAtaque(direccionInicial, danio);
            Destroy(gameObject);
        }
    }
}
