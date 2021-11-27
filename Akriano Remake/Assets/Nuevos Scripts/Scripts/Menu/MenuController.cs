using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Button BtnJugar;
    public Button BtnOpciones;
    public Button BtnCerrar;
    public Image CuadroCreditos;
    public Image EfectoOscurecer;
    public Text TextoCreditos;
    public Image TransicionEscena;

    public float transicionAlphaSpd;
    public bool transicionInicio;
    public bool transicionJugar;

    //Image transicion;
    //bool enTransicion;
    

    // Start is called before the first frame update
    void Start()
    {
        BtnJugar.onClick.AddListener (Jugar);
        BtnCerrar.onClick.AddListener (CerrarOpciones);
        BtnOpciones.onClick.AddListener (AbrirOpciones);

        CuadroCreditos.enabled = false;
        EfectoOscurecer.enabled = false;
        TransicionEscena.enabled = true;
        TextoCreditos.gameObject.SetActive(false);
        BtnCerrar.gameObject.SetActive(false);
        BtnJugar.gameObject.SetActive (true);

        transicionInicio = true;
        transicionJugar = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transicionInicio == true)
        {
            var tempColor = TransicionEscena.color;
            tempColor.a -= transicionAlphaSpd;
            TransicionEscena.color = tempColor;

            if (TransicionEscena.color.a <= 0)
            {
                transicionInicio = false;
                TransicionEscena.enabled = false;          
            }
        }
        else if (transicionJugar == true)
        {
            var tempColor = TransicionEscena.color;
            tempColor.a += transicionAlphaSpd;
            TransicionEscena.color = tempColor;

            if (TransicionEscena.color.a >= 1)
            {
                //Lleva al primer nivel del juego, el cual esta enumerado como "1" en Build Settings.
                SceneManager.LoadScene (1);
            }
        }
    }

    private void Jugar()
    {
        Debug.Log ("Hacia el primer nivel");        
        BtnJugar.enabled = false;
        BtnOpciones.enabled = false;
        TransicionEscena.enabled = true;
        transicionJugar = true;
        //BtnJugar.onClick.RemoveListener (Jugar);
    }

    private void CerrarOpciones()
    {
        Debug.Log ("Opciones Cerradas");
        CuadroCreditos.enabled = false;
        EfectoOscurecer.enabled = false;
        TextoCreditos.gameObject.SetActive (false);
        BtnCerrar.gameObject.SetActive (false);
        BtnOpciones.gameObject.SetActive (true);
        BtnJugar.gameObject.SetActive (true);
    }

    private void AbrirOpciones()
    {
        Debug.Log ("Opciones Abierta");
        CuadroCreditos.enabled = true;
        EfectoOscurecer.enabled = true;
        TextoCreditos.gameObject.SetActive(true);
        BtnCerrar.gameObject.SetActive (true);
        BtnOpciones.gameObject.SetActive (false);
        BtnJugar.gameObject.SetActive (false);
    }
}
