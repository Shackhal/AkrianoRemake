using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministrarSonidos : MonoBehaviour
{
    AudioSource Reproductor;
    public AudioClip MusicaFin;
    void Start()
    {
        Reproductor = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DetenerSonido()
    {
        Reproductor.Stop();
    }
    public void SonidoFinal()
    {
        Reproductor.Stop();
        Reproductor.clip = MusicaFin;
        Reproductor.Play();
    }

}
