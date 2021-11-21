using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float damage;


    Animator anim;
    //Animation animation;
    CircleCollider2D col;

    void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<CircleCollider2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag ("Player"))
        {
            anim.SetTrigger ("Colision");
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag ("Player"))
        {
            anim.SetTrigger ("Colision");
            gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
            col.enabled = false;

            Destroy (gameObject, 0.515f);
        }
        
    }
}
