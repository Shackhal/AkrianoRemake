using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    Enemy enemy;
    public bool isDamage;
    public bool attack;
    public float cronometro;
    public float speed_walk;
    Blink material;
    SpriteRenderer sprite;
    Rigidbody2D rb;
    Animator anim; 
    public int rutina;
    public int direccion;

    public GameObject target;

    Transform objetivo;


    private void Start()
    {
        enemy = GetComponent<Enemy>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Blink>();
        anim = GetComponent<Animator>();
        target = GameObject.Find("Player");
        
    }

    void Update()
    {
        Comportamientos();
    }


    public void Comportamientos() 
    {
        anim.SetBool("Caminar_Enemigo", false);
        cronometro += 1 + Time.deltaTime;

        if (cronometro >= 4) 
        {
            rutina = Random.Range(0, 2);
            cronometro = 0;
        }

        switch (rutina) 
        {
            case 0:
                anim.SetBool("Caminar_Enemigo", false);
                break;

            case 1:
                direccion = Random.Range(0, 2);
                rutina++;
                break;
            case 2:
                
                switch (direccion)
                {
                    case 0:
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                        transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                        break;
                    case 1:
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                        transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                        break;
                }
                anim.SetBool("Caminar_Enemigo", true);
                break;

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
