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

    public int continuaciones;

    private float tamañoBarraVida;

    private Text textoMirarAd;
    private string mirarAd;

    public bool transicionInicioNivel;
    public bool transicionFinNivel;
    public float transicionAlphaSpd;
    public int siguienteNivel;
    //public Enemy enemy;

    //public bool adFinalizado;

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

        textoMirarAd = BtnMirarAd.GetComponentInChildren<Text> ();
        mirarAd = textoMirarAd.text;

        CuadroPausa.enabled = false;
        EfectoOscurecer.enabled = false;
        TransicionEscena.enabled = true;
        ContenidoPausa.gameObject.SetActive (false);
        ContenidoGameOver.gameObject.SetActive (false);

        barraVida.maxValue = player.maxHealth;
        barraVida.value = player.health;
        transicionInicioNivel = true;
        transicionFinNivel = false;

        if (PlayerPrefs.HasKey ("continuaciones"))
        {
            continuaciones = PlayerPrefs.GetInt ("continuaciones");
        }
        else
        {
            PlayerPrefs.SetInt ("continuaciones", continuaciones);
        }
        

        //adFinalizado = false;
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
        TransicionEscena.enabled = true;
        transicionFinNivel = true;

        PlayerPrefs.DeleteKey ("continuaciones");
        //Marcar la escena del Menu Principal, representada como "0" 
        siguienteNivel = 0;
    }
    public void MirarAd()
    {
        Time.timeScale = 0;        
        /*
        if (adFinalizado == true)
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
            
        }
        */

        //adFinalizado = false;
    }

    public void adFinalizado()
    {
        CuadroPausa.enabled = false;
        EfectoOscurecer.enabled = false;
        barraVida.enabled = true;
        player.haRevivido = true;        

        ContenidoGameOver.gameObject.SetActive (false);
        BtnMirarAd.gameObject.SetActive (false);
        BtnSalir.gameObject.SetActive (false);
        BtnPausa.gameObject.SetActive (true);

        continuaciones -= 1;

        Time.timeScale = 1;
    }


    //player.
    //barraVida.value = player.maxHealth;

    private void GameOver()
    {
        CuadroPausa.enabled = true;
        EfectoOscurecer.enabled = true;
        barraVida.enabled = false;
        player.GetComponent<DisparoAuto>().enabled = false;
        //Time.timeScale = 0;

        ContenidoGameOver.gameObject.SetActive (true);
        BtnMirarAd.gameObject.SetActive (true);
        BtnSalir.gameObject.SetActive (true);
        BtnPausa.gameObject.SetActive (false);

        BtnMirarAd.GetComponentInChildren<Text> ().text = mirarAd + " (" + continuaciones + ")";

        if (continuaciones > 0)
        {
            BtnMirarAd.interactable = true;            
        }
        else
        {
            BtnMirarAd.interactable = false;
            //BtnMirarAd.GetComponentInChildren<Text> ().text = mirarAd + " (" + continuaciones + ")";
            textoMirarAd.color = Color.gray;
        }
    }
}