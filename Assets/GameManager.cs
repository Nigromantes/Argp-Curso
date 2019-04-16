using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform playerSpawnPoint;
    public GameObject jugador;
    public static GameManager instance { get; private set; }
    public Transform contendorDeProyectiles; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start () {

       
        jugador = GameObject.FindGameObjectWithTag("Player");
        jugador.transform.position = playerSpawnPoint.position;

    }
		
}
