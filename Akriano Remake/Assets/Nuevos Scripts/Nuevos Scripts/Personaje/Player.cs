using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float health;
    public float maxHealth;
    bool isInmune;
    public float inmunityTime;

    public GameObject projectile;

    public float timeToShoot;
    public float Shootcooldown;

    Transform objetivo;

    Blink material;
    SpriteRenderer sprite;
    Animator anim;

    
    Vector3 target;
    public float speed = 4f;
    Rigidbody2D rb2d;


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Blink>();
        health = maxHealth;
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        target = transform.position;

        Shootcooldown = timeToShoot;
        objetivo = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            target.z = 0f;

            

            anim.SetBool("Caminar", true);
        }
        else
        {
            anim.SetBool("Caminar", false);
            
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        Debug.DrawLine(transform.position, target, Color.green);

        if (health> maxHealth) 
        {
            health = maxHealth;
        }

        Shootcooldown -= Time.deltaTime;



        if (Shootcooldown < 0)
        {
            GameObject bala = Instantiate(projectile, transform.position, Quaternion.identity);

            if (transform.localScale.x < 0)
            {
                bala.GetComponent<Rigidbody2D>().AddForce(new Vector2(300f, 0f), ForceMode2D.Force);
            }

            else
            {
                bala.GetComponent<Rigidbody2D>().AddForce(new Vector2(-300f, 0f), ForceMode2D.Force);
            }

            Shootcooldown = timeToShoot;

        }


    }

    



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !isInmune) 
        {
            health -= collision.GetComponent<Enemy>().damageToGive;
            StartCoroutine(Inmunity());
            if (health <= 0) 
            {
                anim.SetTrigger("Muerte");
                this.enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                Destroy(gameObject, 4);
            }
        }
                


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
