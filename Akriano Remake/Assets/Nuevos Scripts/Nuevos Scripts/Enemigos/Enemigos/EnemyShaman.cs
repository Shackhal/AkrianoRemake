using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShaman : MonoBehaviour
{
    Enemy enemy;
    public bool isDamage;
    public float speed;
    public float visionRadius;
    public GameObject proyectil;
    public float timeToShoot;
    public float Shootcooldown;
    public float balaSpd;


    Blink material;
    SpriteRenderer sprite;
    Rigidbody2D rb;
    Animator anim;


    GameObject Player;

    Transform objetivo;
    Vector3 initialPosition;

    public AudioClip ataqueShaman;
    private AudioSource audioSource;

    public AudioClip dañoShaman;
    //private AudioSource audioDolor;


    private void Start()
    {
        enemy = GetComponent<Enemy> ();
        rb = GetComponent<Rigidbody2D> ();
        sprite = GetComponent<SpriteRenderer> ();
        material = GetComponent<Blink> ();
        anim = GetComponent<Animator> ();

        audioSource = GetComponentInChildren<AudioSource>();
        //audioDolor = GetComponentInChildren<AudioSource>();

        Player = GameObject.FindGameObjectWithTag ("Player");

        initialPosition = transform.position;
        Shootcooldown = timeToShoot;
    }

    void Update()
    {
        Vector3 target = transform.position;

        if (Shootcooldown > 0)
        {
            Shootcooldown -= Time.deltaTime;
        }

        float v = Vector3.Distance (Player.transform.position, transform.position);
        float dist = v;
        if (dist <= visionRadius)
        {

            

            target = Player.transform.position;

            if (target.x > transform.position.x)
            {
                sprite.flipX = false;
            }
            else
            {
                sprite.flipX = true;
            }

            if (Shootcooldown <= 0 && dist <= visionRadius)
            {
                Vector3 balaDir = (target - transform.position).normalized;
                GameObject bala = Instantiate (proyectil, transform.position, Quaternion.identity);
                bala.GetComponent<Rigidbody2D> ().velocity = balaDir * balaSpd * Time.deltaTime;
                Shootcooldown = timeToShoot;

                audioSource.clip = ataqueShaman;

                audioSource.Play();


            }
            anim.SetTrigger ("Atacar_Enemigo");
            //anim.SetBool ("Atacar_Enemigo", true);
            //anim.SetBool ("Caminar_Enemigo", false);

        }
        else
        {
            //target = Player.transform.position;
            //float fixedSpeed = speed * Time.deltaTime;
            //transform.position = Vector3.MoveTowards (transform.position, target, fixedSpeed);
            //anim.SetTrigger ("Caminar_Enemigo");
            //anim.SetBool ("Caminar_Enemigo", true);
            //anim.SetBool ("Atacar_Enemigo", false);
        }

        float fixedSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards (transform.position, target, fixedSpeed);

        //transform.position = Vector3.MoveTowards (transform.position, target, fixedSpeed);

        //Debug.DrawLine (transform.position, target, Color.red);
           


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere (transform.position, visionRadius);
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag ("Kill") && !isDamage)
        {

            if (collision.transform.position.x < transform.position.x)
            {
                rb.AddForce (new Vector2 (enemy.knockbackForceX, enemy.knockbackForceY), ForceMode2D.Force);
            }
            else
            {
                rb.AddForce (new Vector2 (-enemy.knockbackForceX, enemy.knockbackForceY), ForceMode2D.Force);
            }
            Debug.Log (collision.gameObject.tag);
            enemy.healthPoints -= 5f;
            StartCoroutine (Damager ());
            if (enemy.healthPoints <= 0)
            {
                anim.SetTrigger ("Muerte_Enemigo");
                this.enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
                Destroy (gameObject, 4);
            }
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag ("Kill") && !isDamage)
        {

            audioSource.clip = dañoShaman;

            audioSource.Play();



            if (collision.transform.position.x < transform.position.x)
            {
                rb.AddForce (new Vector2 (enemy.knockbackForceX, enemy.knockbackForceY), ForceMode2D.Force);
            }
            else
            {
                rb.AddForce (new Vector2 (-enemy.knockbackForceX, enemy.knockbackForceY), ForceMode2D.Force);
            }
            Debug.Log (collision.gameObject.tag);
            
            enemy.healthPoints -= collision.GetComponent<PlayerProjectile> ().damage;

            StartCoroutine (Damager ());
            if (enemy.healthPoints <= 0)
            {
                anim.SetTrigger ("Muerte_Enemigo");
                this.enabled = false;
                GetComponent<BoxCollider2D> ().enabled = false;
                Destroy (gameObject, 1f);
            }


        }
    }


    IEnumerator Damager()
    {
        isDamage = true;
        sprite.material = material.blink;
        yield return new WaitForSeconds (0.1f);
        sprite.material = material.original;
        isDamage = false;

    }
}
