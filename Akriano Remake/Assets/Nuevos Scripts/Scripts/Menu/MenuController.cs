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

    // Start is called before the first frame update
    void Start()
    {
        BtnJugar.onClick.AddListener (Jugar);
        BtnCerrar.onClick.AddListener (CerrarOpciones);
        BtnOpciones.onClick.AddListener (AbrirOpciones);

        CuadroCreditos.enabled = false;
        EfectoOscurecer.enabled = false;
        TextoCreditos.gameObject.SetActive(false);
        BtnCerrar.gameObject.SetActive(false);
        BtnJugar.gameObject.SetActive (true);
    }

    // Update is called once per frame
    void Update()
    {
        
        //BtnJugar.onClick.RemoveListener (Jugar);
    }

    private void Jugar()
    {
        Debug.Log ("Hacia el primer nivel");
        SceneManager.LoadScene ("Mundo Hierba");
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
