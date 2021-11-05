using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float health;
    public float maxHealth;
    bool isInmune;
    public float inmunityTime;

    private bool estaMuerto;
     
    Blink material;
    SpriteRenderer sprite;
    Animator anim;
        
    Vector3 target;
    public float speed = 4f;
    Rigidbody2D rb2d;

    Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Blink>();
        health = maxHealth;
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        target = transform.position;        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            target.z = 0f;
                                               
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
            anim.SetTrigger("Muerte");
            estaMuerto = true;
            this.enabled = false;
            gameObject.GetComponent<BoxCollider2D> ().enabled = false;
            //Destroy (gameObject, 20);
        }
        else if (estaMuerto && health > 0)
        {
            estaMuerto = false;
            anim.SetTrigger("Revivir");
            this.enabled = true;
            gameObject.GetComponent<BoxCollider2D> ().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !isInmune)
        {
            health -= collision.GetComponent<Enemy>().damageToGive;
            StartCoroutine(Inmunity());
            
        }
        else if (collision.CompareTag ("ProyectilEnemy") && !isInmune)
        {
            health -= collision.GetComponent<Projectile> ().damage;
            StartCoroutine (Inmunity ());
            
        }

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

    IEnumerator Inmunity() 
    {
        isInmune = true;
        sprite.material = material.blink;
        yield return new WaitForSeconds(inmunityTime);
        sprite.material = material.original;
        isInmune = false;
    }
}
