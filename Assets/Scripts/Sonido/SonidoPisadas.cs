using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoPisadas : MonoBehaviour {

    private AudioSource audioSource;

    [SerializeField]
    [Range(-3, 3)]
    private float pitchMinimo;

    [SerializeField]
    [Range(-3, 3)]
    private float pitchMaximo;


    // Use this for initialization
    void Start () {

        audioSource = GetComponent<AudioSource>();
		
	}

    public void ReproducirSonidoPasos()
    {

        audioSource.pitch = Random.Range(0.9f,1.1f);
        audioSource.Play();

    }
	
	
}
