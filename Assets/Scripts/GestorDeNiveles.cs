using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorDeNiveles : MonoBehaviour {

	public void CargarSiguienteNivel()
    {
        int escenaACtualIndice = SceneManager.GetActiveScene().buildIndex;
        int singuienteEscenaIndice = ++escenaACtualIndice;
        SceneManager.LoadScene(singuienteEscenaIndice);
    }
}
