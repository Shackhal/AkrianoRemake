using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoHellish : MonoBehaviour
{
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void ReproducirSonido()
    {
        audioSource.Play();
    }
}
