using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float damage;

    Animator anim;
    //Animation animState;
    BoxCollider2D col;

    //AnimationState state;

    //private bool explosion;

    void Start()
    {
        anim = GetComponent<Animator> ();
        //animState = GetComponent<Animation> ();
        col = GetComponent<BoxCollider2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (explosion == true)
        {
            if (animState. >= animState.length)
            {
                Destroy (this);
            }
        }*/
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag ("Enemy"))
        {
            anim.SetTrigger ("Colision");
            gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);

            explosion = true;

            //animState.length
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag ("Enemy"))
        {
            anim.SetTrigger ("Colision");
            gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
            col.enabled = false;

            Destroy (gameObject, 0.515f);
        }

    }
}
