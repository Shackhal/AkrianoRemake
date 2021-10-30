using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispararPersonaje : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Bala_Player_Original;

    GameObject objetivo;

    void Start()
    {
        objetivo = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        //1 Primer disparo es con el mouse
        if (Input.GetButtonDown("Fire2"))
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
                      

            
        }
    }
}
