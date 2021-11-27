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

    public AudioClip explosion;
    private AudioSource audioSource;

    void Start()
    {
        anim = GetComponent<Animator> ();
        //animState = GetComponent<Animation> ();
        col = GetComponent<BoxCollider2D> ();

        audioSource = GetComponentInChildren<AudioSource> ();
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
        if (collision.CompareTag ("Enemy") || collision.CompareTag("Escenario") || collision.CompareTag ("Puerta"))
        {
            anim.SetTrigger ("Colision");
            gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
            col.enabled = false;

            audioSource.clip = explosion;
            audioSource.Play ();

            Destroy (gameObject, 0.515f);
        }

    }
}
