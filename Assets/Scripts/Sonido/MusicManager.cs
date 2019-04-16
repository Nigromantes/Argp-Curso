using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip[] PistasMusicales;
    public static MusicManager instance;
    private AudioSource audioSource;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
        ReproducirMusica(0);
	}

    public void ReproducirMusica(int indice)
    {
        audioSource.clip = PistasMusicales[indice];
        audioSource.Play();
    }

}
