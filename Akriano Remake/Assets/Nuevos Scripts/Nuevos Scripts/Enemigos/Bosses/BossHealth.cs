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
    public float balaSpd;

    Blink material;
    SpriteRenderer sprite;
    Rigidbody2D rb;
    Animator anim;    

    GameObject Player;

    Transform objetivo;
    Vector3 initialPosition;

    public AudioClip estandarHellish;
    public AudioClip ataqueHellish;
    private AudioSource audioSource;

    public AudioClip dañoHellish;
    //private AudioSource audioMuerte;


    private void Start()
    {
        Boss = GetComponent<Enemy>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Blink>();
        anim = GetComponent<Animator>();
        audioSource = GetComponentInChildren<AudioSource>();
        //audioMuerte = GetComponentInChildren<AudioSource>();

        audioSource.Play ();
        audioSource.loop = true;

        Shootcooldown = timeToShoot;

        //audioSource.clip = estandarHellish;

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
                Vector3 balaDir = (target - transform.position).normalized;
                GameObject bala = Instantiate (proyectil, transform.position, Quaternion.identity);
                bala.GetComponent<Rigidbody2D> ().velocity = balaDir * balaSpd * Time.deltaTime;
                Shootcooldown = timeToShoot;

                audioSource.clip = ataqueHellish;
                audioSource.Play();
                audioSource.loop = false;
            }

        }

        else
        {
            anim.SetBool("Atacar_Enemigo", false);
            if (audioSource.clip != estandarHellish && audioSource.clip != dañoHellish)
            {
                audioSource.clip = estandarHellish;
                audioSource.Play ();
                audioSource.loop = true;
            }
            
        }

        Debug.DrawLine(transform.position, target, Color.black);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log ("Muereee");
        if (collision.gameObject.CompareTag ("Kill") && !isDamage)

        {
            Debug.Log (collision.gameObject.tag);
            Boss.healthPoints -= 5f;

            StartCoroutine (Damager ());
            if (Boss.healthPoints <= 0)
            {
                anim.SetTrigger ("Muerte_Enemigo");
                this.enabled = false;
                GetComponent<BoxCollider2D> ().enabled = false;
                Destroy (gameObject, 4);
            }
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Muereee");
        if (collision.CompareTag("Kill") && !isDamage)

        {

            audioSource.clip = dañoHellish;

            audioSource.Play();
            audioSource.loop = false;

            Debug.Log(collision.gameObject.tag);
            Boss.healthPoints -= collision.GetComponent<PlayerProjectile> ().damage;

            StartCoroutine (Damager());
            if (Boss.healthPoints <= 0)
            {
                anim.SetTrigger("Muerte_Enemigo");
                this.enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
                Destroy(gameObject, 3f);
            }
        }
    }

    IEnumerator Damager()
    {
        isDamage = true;
        sprite.material = material.blink;
        yield return new WaitForSeconds (0.5f);
        sprite.material = material.original;
        isDamage = false;

    }

    
}

