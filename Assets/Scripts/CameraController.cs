using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour {

    private CinemachineVirtualCamera cv;
    
    // Use this for initialization
	private void Start () {

        cv = GetComponent<CinemachineVirtualCamera>();

        Transform jugador = GameManager.instance.jugador.transform;

        cv.m_Follow = jugador; 
		
	}
	
	
}
