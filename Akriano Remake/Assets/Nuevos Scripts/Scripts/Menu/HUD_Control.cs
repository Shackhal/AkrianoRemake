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
    public Text ContenidoPausa;
    public Text ContenidoGameOver;
    public Player player;

    private float tamañoBarraVida;
    //public Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy> ();

        BtnPausa.onClick.AddListener (Pausa);
        BtnContinuar.onClick.AddListener (Continuar);
        BtnSalir.onClick.AddListener (SalirAMenu);
        BtnMirarAd.onClick.AddListener (MirarAd);

        BtnContinuar.gameObject.SetActive (false);
        BtnSalir.gameObject.SetActive (false);
        BtnPausa.gameObject.SetActive (true);
        BtnMirarAd.gameObject.SetActive (false);

        CuadroPausa.enabled = false;
        ContenidoPausa.gameObject.SetActive (false);
        ContenidoGameOver.gameObject.SetActive (false);

        barraVida.maxValue = player.maxHealth;
        barraVida.value = player.health;
    }

    // Update is called once per frame
    void Update()
    {
        barraVida.value = player.health;

        if (barraVida.value <= 0.4f)
        {
            
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
        barraVida.enabled = false;
        player.gameObject.SetActive (false);
        ContenidoPausa.gameObject.SetActive (true);
        BtnContinuar.gameObject.SetActive (true);
        BtnSalir.gameObject.SetActive (true);
        BtnPausa.gameObject.SetActive (false);
    }
    private void Continuar()
    {
        CuadroPausa.enabled = false;
        barraVida.enabled = true;
        player.gameObject.SetActive (true);
        ContenidoPausa.gameObject.SetActive (false);
        BtnContinuar.gameObject.SetActive (false);
        BtnSalir.gameObject.SetActive (false);
        BtnPausa.gameObject.SetActive (true);
    }
    private void SalirAMenu()
    {
        SceneManager.LoadScene ("MenuPrincipal");
    }
    private void MirarAd()
    {
        CuadroPausa.enabled = false;
        barraVida.enabled = true;
        
        //player.enabled = true;
        ContenidoGameOver.gameObject.SetActive (false);
        BtnMirarAd.gameObject.SetActive (false);
        BtnSalir.gameObject.SetActive (false);
        BtnPausa.gameObject.SetActive (true);

        player.health = player.maxHealth;
        //player.
        //barraVida.value = player.maxHealth;
    }
    private void GameOver()
    {
        CuadroPausa.enabled = true;
        barraVida.enabled = false;
        //player.enabled = false;
        ContenidoGameOver.gameObject.SetActive (true);
        BtnMirarAd.gameObject.SetActive (true);
        BtnSalir.gameObject.SetActive (true);
        BtnPausa.gameObject.SetActive (false);
    }
}