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


    private void Start()
    {
        enemy = GetComponent<Enemy>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Blink>();
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
                Destroy(gameObject);
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
