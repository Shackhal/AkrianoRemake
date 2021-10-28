using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    Enemy enemy;
    public bool isDamage;
    Blink material;
    SpriteRenderer sprite;
    Rigidbody2D rb;
    Animator anim;

    public GameObject projectile;

    public float timeToShoot;
    public float Shootcooldown;

    Transform objetivo;


    private void Start()
    {
        enemy = GetComponent<Enemy>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Blink>();
        anim = GetComponent<Animator>();

        Shootcooldown = timeToShoot;
        objetivo = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    void Update()
    {

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
        if (collision.CompareTag("Kill") && !isDamage) 
        {
            enemy.healthPoints -= 5f;
            if (collision.transform.position.x < transform.position.x) 
            {
                rb.AddForce(new Vector2(enemy.knockbackForceX, enemy.knockbackForceY), ForceMode2D.Force);
            }
            else 
            {
                rb.AddForce(new Vector2(-enemy.knockbackForceX, enemy.knockbackForceY), ForceMode2D.Force);
            }



            _ = StartCoroutine(Damager());
            if (enemy.healthPoints <= 0) 
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
