using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{

    Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) 
        {
            
            
                anim.SetTrigger("Colision");
                this.enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                Destroy(gameObject, 2);
            
        }
    }
}
