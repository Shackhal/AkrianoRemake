using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar_Enemigo : MonoBehaviour
{
    // Start is called before the first frame update
    public float t = 0;//contar el tiempo
    public float t_max = 1.5f;//cadencia de fuego
    public float damegeToGive; 
    SpriteRenderer sprite;
    public GameObject projectile;

    Transform objetivo;
    void Start()
    {
        objetivo = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (t < t_max)
        {

            GameObject bala = Instantiate(projectile, transform.position, Quaternion.identity);
            t += Time.deltaTime;

        }
        else
        {
            //dispare-------
            //crear bala
            GameObject bala = new GameObject();
            bala.name = "bala";
            bala.AddComponent<SpriteRenderer>();
            bala.GetComponent<SpriteRenderer>().sortingOrder = 2;
            bala.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
            bala.GetComponent<SpriteRenderer>().color = Color.red;
            bala.transform.position = transform.position;
            bala.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

            //la bala se dispare
            bala.AddComponent<Rigidbody2D>();
            bala.GetComponent<Rigidbody2D>().gravityScale = 0;
            //agregarla la fuerza a la bala
            bala.GetComponent<Rigidbody2D>().AddForce((objetivo.position - transform.position) * 100.0f);
            //--------------
            t = 0;
        }
    }
}
