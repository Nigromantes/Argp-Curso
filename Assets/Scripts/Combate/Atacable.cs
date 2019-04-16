using UnityEngine;
using UnityEngine.Events;

public class Atacable : MonoBehaviour {

    private Salud miSalud;
    public UnityEvent OnMorir;
    private Rigidbody2D MiRigidBody; 

    private void Start()
    {
        miSalud = GetComponent<Salud>();
        MiRigidBody = GetComponent<Rigidbody2D>();
    }

    public void RecibirAtaque()
    {

        miSalud.SaludActual -= 1;
        //Destroy(gameObject,1f);
        Debug.Log("EstoyRecibiendo un ataque");
    }

    public void RecibirAtaque( Vector2 direcciondeAtaque, int danio)
    {

        miSalud.ModificarSaludActual(-danio);
        MiRigidBody.AddForce(direcciondeAtaque * danio*100);

        
    }
}
