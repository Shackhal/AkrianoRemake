using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicaEnemigo : MonoBehaviour
{
    // Start is called before the first frame update
    public int Vida_Enemigo;

    bool indicador = false;
    float t;//contador de tiempo
    public float tiempo_recuperacion = 0.25f;

    public Animator animator;
    private float checkPointPositionX, checkPointPositionY;

    void Start()
    {
        if (PlayerPrefs.GetFloat("checkPointPositionX") != 0)
        {
            transform.position = (new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("chechPointPositionY")));
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (indicador == true)
        {

            if (t < tiempo_recuperacion)
            {
                t += Time.deltaTime;
            }
            else
            {
                //reinicio de color
                GetComponent<SpriteRenderer>().color = Color.white;
                t = 0;
                indicador = false;
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Kill")
        {

            if (Vida_Enemigo >= 0)
            {
                Vida_Enemigo -= 10;

                GetComponent<SpriteRenderer>().color = Color.red;
                indicador = true;
                t = 0;
                Debug.Log(Vida_Enemigo);
            }
            else
            {
                //voy a crear un nuevo objeto antes de que el enemigo se desactive

                gameObject.SetActive(false);

            }
            //Destruir la bala
            Destroy(collision.gameObject);

        }
        /*if (collision.gameObject.tag == "Player")
        {

            //haciendo la priemra prueba
            GameObject.Find("Reproductor").GetComponent<AdministrarSonidos>().SonidoFinal();
            //Activo la animacion
            GameObject.Find("Flujo").GetComponent<AdministrarFlujo>().ActivarAnimacionFinal();


        }*/

        

    }
    public void ReachedCheckPoint(float x, float y)
    {
        PlayerPrefs.SetFloat("checkPointPosition", x);
        PlayerPrefs.SetFloat("checkPointPosition", y);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
