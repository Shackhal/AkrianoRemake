using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD_Control : MonoBehaviour
{
    public Slider barraVida;

    public Button BtnPausa;
    public Button BtnContinuar;
    public Button BtnMirarAd;
    public Button BtnSalir;
    public Image CuadroPausa;
    public Image EfectoOscurecer;
    public Text ContenidoPausa;
    public Text ContenidoGameOver;
    public Player player;
    public Image TransicionEscena;

    private float tamañoBarraVida;

    public bool transicionInicioNivel;
    public bool transicionFinNivel;
    public float transicionAlphaSpd;
    public int siguienteNivel;
    //public Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        //Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy> ();

        BtnPausa.onClick.AddListener (Pausa);
        BtnContinuar.onClick.AddListener (Continuar);
        BtnSalir.onClick.AddListener (SalirAMenu);
        BtnMirarAd.onClick.AddListener (MirarAd);

        BtnContinuar.gameObject.SetActive (false);
        BtnSalir.gameObject.SetActive (false);
        BtnPausa.gameObject.SetActive (true);
        BtnMirarAd.gameObject.SetActive (false);

        CuadroPausa.enabled = false;
        EfectoOscurecer.enabled = false;
        TransicionEscena.enabled = true;
        ContenidoPausa.gameObject.SetActive (false);
        ContenidoGameOver.gameObject.SetActive (false);

        barraVida.maxValue = player.maxHealth;
        barraVida.value = player.health;
        transicionInicioNivel = true;
        transicionFinNivel = false;        
    }

    // Update is called once per frame
    void Update()
    {
        if (transicionInicioNivel == true)
        {
            var tempColor = TransicionEscena.color;
            tempColor.a -= transicionAlphaSpd;
            TransicionEscena.color = tempColor;

            if (TransicionEscena.color.a <= 0)
            {
                TransicionEscena.enabled = false;
                transicionInicioNivel = false;                
            }
        }
        else if (transicionFinNivel == true)
        {
            var tempColor = TransicionEscena.color;
            tempColor.a += transicionAlphaSpd;
            TransicionEscena.color = tempColor;

            if (TransicionEscena.color.a >= 1)
            {
                SceneManager.LoadScene (siguienteNivel);
            }
        }
        
        barraVida.value = player.health;

        if (barraVida.value <= 0.2f)
        {
            //barraVida.fillRect.GetComponent<Image> ().color = Color.red;
        }
        else
        {
            //barraVida.fillRect.GetComponent<Image> ().color = Color.clear;
        }

        if (barraVida.value <= 0)
        {
            barraVida.value = 0;
            GameOver ();
        }
    }

    private void Pausa()
    {
        CuadroPausa.enabled = true;
        EfectoOscurecer.enabled = true;
        //barraVida.enabled = false;
        player.enabled = false;
        Time.timeScale = 0;
        ContenidoPausa.gameObject.SetActive (true);
        BtnContinuar.gameObject.SetActive (true);
        BtnSalir.gameObject.SetActive (true);
        BtnPausa.gameObject.SetActive (false);
    }
    private void Continuar()
    {
        CuadroPausa.enabled = false;
        EfectoOscurecer.enabled = false;
        //barraVida.enabled = true;
        player.enabled = true;
        Time.timeScale = 1;
        ContenidoPausa.gameObject.SetActive (false);
        BtnContinuar.gameObject.SetActive (false);
        BtnSalir.gameObject.SetActive (false);
        BtnPausa.gameObject.SetActive (true);
    }
    private void SalirAMenu()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }        
        SceneManager.LoadScene ("MenuPrincipal");
    }
    private void MirarAd()
    {
        CuadroPausa.enabled = false;
        EfectoOscurecer.enabled = false;
        barraVida.enabled = true;
        
        ContenidoGameOver.gameObject.SetActive (false);
        BtnMirarAd.gameObject.SetActive (false);
        BtnSalir.gameObject.SetActive (false);
        BtnPausa.gameObject.SetActive (true);

        Time.timeScale = 1;
        player.enabled = true;
        player.health = player.maxHealth;
        player.estaMuerto = false;
        player.GetComponent<BoxCollider2D> ().enabled = true;
        player.GetComponent<Animator> ().SetTrigger ("Revivir");
        //player.
        //barraVida.value = player.maxHealth;
    }
    private void GameOver()
    {
        CuadroPausa.enabled = true;
        EfectoOscurecer.enabled = true;
        barraVida.enabled = false;
        //player.enabled = false;
        Time.timeScale = 0;
        ContenidoGameOver.gameObject.SetActive (true);
        BtnMirarAd.gameObject.SetActive (true);
        BtnSalir.gameObject.SetActive (true);
        BtnPausa.gameObject.SetActive (false);
    }
}