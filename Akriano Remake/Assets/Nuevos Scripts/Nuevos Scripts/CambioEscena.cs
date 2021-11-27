using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioEscena : MonoBehaviour
{
    public HUD_Control infoHUD;

    public int nuevoNivel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Player> ().enabled = false;
        infoHUD.siguienteNivel = nuevoNivel;
        infoHUD.TransicionEscena.enabled = true;
        infoHUD.transicionFinNivel = true;
        PlayerPrefs.SetInt ("continuaciones", infoHUD.continuaciones);
    }
}
