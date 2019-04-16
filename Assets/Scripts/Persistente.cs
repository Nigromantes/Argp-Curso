using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistente : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        NoDestruir();

    }

    private void NoDestruir()
    {
        DontDestroyOnLoad(this);
    }

   
}
