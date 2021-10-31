using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public GameObject projectile;
    
    public float timeToShoot;
    public float Shootcooldown;

    Transform objetivo;
    Animator anim;

    void Start()
    {
        Shootcooldown = timeToShoot;
        objetivo = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Shootcooldown -= Time.deltaTime;



        if (Shootcooldown < 0) 
        {
           GameObject bala = Instantiate(projectile, transform.position, Quaternion.identity);

            if(transform.localScale.x < 0) 
            {
                anim.SetBool("Atacar_Enemigo", true);
                bala.GetComponent<Rigidbody2D>().AddForce(new Vector2(300f, 0f), ForceMode2D.Force);
            }

            else 
            {
                bala.GetComponent<Rigidbody2D>().AddForce(new Vector2(-300f, 0f), ForceMode2D.Force);
            }

            Shootcooldown = timeToShoot;

            
        }

        

    }
}
