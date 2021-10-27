using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float health;
    public float maxHealth;
    bool isInmune;
    public float inmunityTime;
    Blink material;
    SpriteRenderer sprite;
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Blink>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
      if(health> maxHealth) 
        {
            health = maxHealth;
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
                Destroy(gameObject);
                anim.SetTrigger("Muerte");
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
