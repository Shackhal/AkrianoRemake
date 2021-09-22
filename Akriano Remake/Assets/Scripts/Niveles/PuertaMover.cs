using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaMover : MonoBehaviour
{
    public int direccion;
    public float duracion = 1.0f;

    public int Cuarto_Objetivo;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //el player no deberia moverse
            collision.gameObject.GetComponent<MovementCharacter>().enabled = false;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            //deberia hacer el movimiento
            Vector3 posicion_actual_camara = Camera.main.transform.position;
            Vector2 nueva_posicion;
            float x_;
            float y_;

            Vector2 posicion_puerta;
            Vector2 nueva_posicion_player;
            Vector2 posicion_actual_player;


            Camera.main.GetComponent<MotorCuarto>().ApagarEnemigosActuales();

            switch (direccion)
            {
                case 0://izquierda
                    x_ = posicion_actual_camara.x - 21.95f;
                    y_ = posicion_actual_camara.y;
                    nueva_posicion = new Vector2(x_, y_);
                    StartCoroutine(CambioPosicion(new Vector3(x_, y_, 0)));

                    //moviendo al personaje
                    //obteniendo la posicion de la puerta con la que choco:
                    posicion_puerta = gameObject.transform.position;
                    collision.gameObject.transform.position = posicion_puerta;
                    posicion_actual_player = collision.gameObject.transform.position;
                    //generando nueva posicion para el player
                    nueva_posicion_player = new Vector2(posicion_actual_player.x - 3.0f, posicion_actual_player.y);
                    //asiganr la nueva posicion al player
                    //collision.gameObject.transform.position = nueva_posicion_player;
                    StartCoroutine(CambioPosicionPlayer(nueva_posicion_player, collision.gameObject));


                    break;

                case 1://derecha
                    x_ = posicion_actual_camara.x + 21.95f;
                    y_ = posicion_actual_camara.y;
                    nueva_posicion = new Vector2(x_, y_);
                    StartCoroutine(CambioPosicion(new Vector3(x_, y_, 0)));

                    //moviendo al personaje
                    //obteniendo la posicion de la puerta con la que choco:
                    //moviendo al personaje
                    //obteniendo la posicion de la puerta con la que choco:
                    posicion_puerta = gameObject.transform.position;
                    collision.gameObject.transform.position = posicion_puerta;
                    posicion_actual_player = collision.gameObject.transform.position;
                    //generando nueva posicion para el player
                    nueva_posicion_player = new Vector2(posicion_actual_player.x + 3.0f, posicion_actual_player.y);
                    //asiganr la nueva posicion al player
                    StartCoroutine(CambioPosicionPlayer(nueva_posicion_player, collision.gameObject));

                    break;

                case 2://arriba
                    x_ = posicion_actual_camara.x;
                    y_ = posicion_actual_camara.y + 12.3f;
                    nueva_posicion = new Vector2(x_, y_);
                    StartCoroutine(CambioPosicion(new Vector3(x_, y_, 0)));

                    //moviendo al personaje
                    //obteniendo la posicion de la puerta con la que choco:
                    posicion_puerta = gameObject.transform.position;
                    collision.gameObject.transform.position = posicion_puerta;
                    posicion_actual_player = collision.gameObject.transform.position;
                    //generando nueva posicion para el player
                    nueva_posicion_player = new Vector2(posicion_actual_player.x, posicion_actual_player.y + 4.0f);
                    //asiganr la nueva posicion al player
                    StartCoroutine(CambioPosicionPlayer(nueva_posicion_player, collision.gameObject));

                    break;

                case 3://abajo
                    x_ = posicion_actual_camara.x;
                    y_ = posicion_actual_camara.y - 12.3f;
                    nueva_posicion = new Vector2(x_, y_);
                    StartCoroutine(CambioPosicion(new Vector3(x_, y_, 0)));

                    //moviendo al personaje
                    //obteniendo la posicion de la puerta con la que choco:
                    posicion_puerta = gameObject.transform.position;
                    collision.gameObject.transform.position = posicion_puerta;
                    posicion_actual_player = collision.gameObject.transform.position;
                    //generando nueva posicion para el player
                    nueva_posicion_player = new Vector2(posicion_actual_player.x, posicion_actual_player.y - 4.0f);
                    //asiganr la nueva posicion al player
                    StartCoroutine(CambioPosicionPlayer(nueva_posicion_player, collision.gameObject));
                    break;
            }
        }
    }
    IEnumerator CambioPosicion(Vector3 PosicionFinal)
    {
        //inicio - declaran variables para trabajar
        float t = 0;
        Vector3 PosicionInicial = Camera.main.transform.position;

        //desactivar todo lo que hace el personaje

        //durante
        while (t < duracion)
        {

            Camera.main.transform.position = Vector3.Lerp(PosicionInicial, PosicionFinal, t / duracion);
            t += Time.deltaTime;
            yield return null;
        }
        //fin
        Camera.main.transform.position = PosicionFinal;
        //volver a activar todas las acciones del personaje

    }

    IEnumerator CambioPosicionPlayer(Vector3 PosicionFinal, GameObject _Player)
    {
        //inicio - declaran variables para trabajar
        float t = 0;
        Vector3 PosicionInicial = _Player.transform.position;

        //desactivar todo lo que hace el personaje

        //durante
        while (t < duracion)
        {

            _Player.transform.position = Vector3.Lerp(PosicionInicial, PosicionFinal, t / duracion);
            t += Time.deltaTime;
            yield return null;
        }
        //fin
        _Player.transform.position = PosicionFinal;
        _Player.GetComponent<MovementCharacter>().enabled = true;
        _Player.GetComponent<BoxCollider2D>().enabled = true;
        //ACTIVAR LOS ENEMIGOS DEL CUARTO AL QUE LLEGO
        Camera.main.GetComponent<MotorCuarto>().Index_Cuarto_Actual = Cuarto_Objetivo;
        Camera.main.GetComponent<MotorCuarto>().PrenderEnemigosActuales();

        //volver a activar todas las acciones del personaje

    }
}
