using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuego : MonoBehaviour
{
    public float damegeToGive;
    public float t = 0;
    public float t_max = 1.5f;
    SpriteRenderer sprite;
    Transform objetivo;
    public GameObject Bala_Player_Original;
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

            t += Time.deltaTime;

        }
        else
        {
            GameObject bala = Instantiate(Bala_Player_Original);
            bala.name = "bala";
            bala.tag = "Player";

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
