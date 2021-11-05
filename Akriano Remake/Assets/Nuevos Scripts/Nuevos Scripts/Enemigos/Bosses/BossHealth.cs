using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    Enemy Boss;
    //Boss Boss;
    public bool isDamage;
    public float speed;
    public float visionRadius;
    public float timeToShoot;
    public float Shootcooldown;
    public GameObject proyectil;

    Blink material;
    SpriteRenderer sprite;
    Rigidbody2D rb;
    Animator anim;

    

    GameObject Player;

    Transform objetivo;
    Vector3 initialPosition;

    private void Start()
    {
        Boss = GetComponent<Enemy>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Blink>();
        anim = GetComponent<Animator>();

        Shootcooldown = timeToShoot;

        objetivo = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    void Update()
    {

        Vector3 target = initialPosition;

        if (Shootcooldown > 0)
        {
            Shootcooldown -= Time.deltaTime;
        }

        float dist = Vector3.Distance(objetivo.transform.position, transform.position);
        if (dist < visionRadius)
        {
            target = objetivo.transform.position;

            anim.SetBool("Atacar_Enemigo", true);

            if (Shootcooldown <= 0 && dist <= visionRadius)
            {
                GameObject bala = Instantiate (proyectil, transform.position, Quaternion.identity);
                bala.GetComponent<Rigidbody2D> ().velocity = (target - transform.position) * new Vector2 (1f, 1f);
                Shootcooldown = timeToShoot;
            }

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
            Boss.healthPoints -= 5f;
            
            StartCoroutine(Damager());
            if (Boss.healthPoints <= 0)
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

