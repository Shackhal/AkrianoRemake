using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispararPersonaje : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Bala_Player_Original;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //1 Primer disparo es con el mouse
        if (Input.GetMouseButtonDown(0))
        {
            //comenzamos a crear nuestras copias
            GameObject bala_clon = Instantiate(Bala_Player_Original);
            //donde debe originarse
            bala_clon.transform.position = transform.position;
            //Disparar la bala
            bala_clon.AddComponent<Rigidbody2D>();
            //la bala no se cae
            bala_clon.GetComponent<Rigidbody2D>().gravityScale = 0;
            //agregando colision
            bala_clon.AddComponent<BoxCollider2D>().isTrigger = true;
            bala_clon.tag = "Kill";
            //determinar la direccion
            //necesitamos 2 posiciones
            //la del player
            //la del mouse
            Vector3 mouse_position = Input.mousePosition;//la posicion del mouse en la pantalla
            //convertir posicion de la pantalla al mundo
            Vector3 mouse_position_mundo = Camera.main.ScreenToWorldPoint(mouse_position);
            Vector3 direccion = mouse_position_mundo - transform.position;

            bala_clon.GetComponent<Rigidbody2D>().AddForce(new Vector2(direccion.x, direccion.y) * 250.0f);
        }
    }
}
