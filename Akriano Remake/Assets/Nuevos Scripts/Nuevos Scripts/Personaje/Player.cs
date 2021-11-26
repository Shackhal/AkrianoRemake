using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float health;
    public float maxHealth;
    bool isInmune;
    public float inmunityTime;
    public Camera cam;

    public bool estaMuerto;
     
    Blink material;
    SpriteRenderer sprite;
    Animator anim;
        
    public Vector3 target;
    public float speed;
    Rigidbody2D rb2d;

    Enemy enemy;

    public AudioClip dañoAkriano;
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Blink>();
        health = maxHealth;
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponentInChildren<AudioSource>();

        target = transform.position;
        cam = Camera.main;
        estaMuerto = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.x <= 16*(cam.scaledPixelWidth/18) || Input.mousePosition.y <= 8*(cam.scaledPixelHeight/10))
            {
                target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            }
            
            
            target.z = 0f;
            Debug.Log (Input.mousePosition.x + ", " + Input.mousePosition.y);
            Debug.Log (target.x + ", " + target.y);
                                               
            //anim.SetBool("Caminar", true);

            if (target.x >= transform.position.x) 
            {
                sprite.flipX = false;
            }
            else
            {
                sprite.flipX = true;
            }
        }
        else
        {
            //anim.SetBool("Caminar", false);            
        }

        if (Vector2.Distance(transform.position, target) >= 0.1f)
        {
            anim.SetBool ("Caminar", true);
            transform.position = Vector3.MoveTowards (transform.position, target, speed * Time.deltaTime);
        }
        else
        {
            anim.SetBool ("Caminar", false);
            target = transform.position;
        }        

        Debug.DrawLine(transform.position, target, Color.green);

        if (health > maxHealth) 
        {
            health = maxHealth;
        }

        if (health <= 0)
        {
            anim.SetTrigger ("Muerte");
            estaMuerto = true;            
            gameObject.GetComponent<BoxCollider2D> ().enabled = false;
            this.enabled = false;




            if (estaMuerto == false)
            {
                //gameObject.GetComponent<BoxCollider2D> ().enabled = true;
                //health = maxHealth;
                //estaMuerto = false;
                //anim.SetTrigger ("Revivir");
                //gameObject.GetComponent<BoxCollider2D> ().enabled = true;
            }


            //gameObject.GetComponent<BoxCollider2D> ().enabled = false;
            //Destroy (gameObject, 20);

            


        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag ("Enemy") && !isInmune)
        {
            health -= collision.gameObject.GetComponent<Enemy> ().damageToGive;
            StartCoroutine (Inmunity ());

            audioSource.clip = dañoAkriano;

            audioSource.Play();

            //if (health <= 0)
            //{
            //    anim.SetTrigger ("Muerte");
            //    estaMuerto = true;
            //    this.enabled = false;

            //}
        }
            /*
            if (collision.gameObject.CompareTag ("ProyectilEnemy") && !isInmune)
            {
                health -= collision.gameObject.GetComponent<Projectile> ().damage;
                StartCoroutine (Inmunity ());

            }
            */

            /*
            if (health <= 0)
            {
                anim.SetBool ("Muerte", true);
                estaMuerto = true;
                this.enabled = false;
                gameObject.GetComponent<BoxCollider2D> ().enabled = false;
                //Destroy (gameObject, 20);
            }
            */

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag ("ProyectilEnemy") && !isInmune)
        {
            health -= collision.GetComponent<EnemyProjectile> ().damage;
            StartCoroutine (Inmunity ());

            audioSource.clip = dañoAkriano;

            audioSource.Play();

            //if (health <= 0)
            //{
            //    anim.SetTrigger ("Muerte");
            //    estaMuerto = true;
            //    this.enabled = false;
            //}
        }
        
        /*if (health <= 0)
        {
            anim.SetBool ("Muerte", true);
            estaMuerto = true;
            this.enabled = false;
            gameObject.GetComponent<BoxCollider2D> ().enabled = false;
            //Destroy (gameObject, 20);
        }*/
        
    }

    IEnumerator Inmunity() 
    {
        isInmune = true;
        sprite.material = material.blink;
        yield return new WaitForSeconds(inmunityTime);
        sprite.material = material.original;
        isInmune = false;
    }

    


}
