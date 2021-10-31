using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

    Boss Boss;
    public bool isDamage;
    public float speed;
    public float visionRadius;

    Blink material;
    SpriteRenderer sprite;
    Rigidbody2D rb;
    Animator anim;

    

    GameObject Player;

    Transform objetivo;
    Vector3 initialPosition;

    private void Start()
    {
        Boss = GetComponent<Boss>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Blink>();
        anim = GetComponent<Animator>();

        
        objetivo = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    void Update()
    {

        Vector3 target = initialPosition;

        float dist = Vector3.Distance(Player.transform.position, transform.position);
        if (dist < visionRadius)
        {
            target = Player.transform.position;

            anim.SetBool("Atacar_Enemigo", true);

        }

        else
        {
            anim.SetBool("Atacar_Enemigo", false);
        }

        Debug.DrawLine(transform.position, target, Color.black);

        



        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Muereee");
        if (collision.CompareTag("Kill") && !isDamage)

        {
            Debug.Log(collision.gameObject.tag);
            Boss.BosshealthPoints -= 5f;
            
            StartCoroutine(Damager());
            if (Boss.BosshealthPoints <= 0)
            {
                anim.SetTrigger("Muerte_Enemigo");
                this.enabled = false;
                GetComponent<Collider2D>().enabled = false;
                Destroy(gameObject, 12);
            }
        }
    }

    IEnumerator Damager()
    {
        isDamage = true;
        sprite.material = material.blink;
        yield return new WaitForSeconds(0.5f);
        sprite.material = material.original;
        isDamage = false;

    }



}

