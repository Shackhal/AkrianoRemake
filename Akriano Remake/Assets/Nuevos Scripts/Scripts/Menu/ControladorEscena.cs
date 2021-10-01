using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorEscena : MonoBehaviour
{

    public void CambiarEscena(string nombre)
    {
        print("Cambiando a la Escena" + nombre);
        SceneManager.LoadScene(nombre);
    }

    
}
