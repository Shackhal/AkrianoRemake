using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoAuto : MonoBehaviour
{
    public AudioClip sonidoAtaque;
    private AudioSource audioSource;

    public GameObject projectile;

    public float timeToShoot;
    public float Shootcooldown;
    public float visualRadius;
    public float balaSpd;

    Transform objetivo;
    Vector3 enemyPosition;
    //GameObject bala;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        
        Shootcooldown = timeToShoot;
        //objetivo = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyPosition = FindClosestEnemy();
        float distanceAttack = Vector2.Distance (transform.position, enemyPosition);

        if (Shootcooldown > 0)
        {
            Shootcooldown -= Time.deltaTime;
        }

        if (Shootcooldown <= 0 && distanceAttack <= visualRadius && enemyPosition != transform.position)
        {
            
            Vector3 direccionBala = (enemyPosition - transform.position).normalized;
            float balaImgAngulo = Mathf.Atan2 (direccionBala.x, direccionBala.y) * Mathf.Rad2Deg - 90f;

            GameObject bala = Instantiate (projectile, transform.position, Quaternion.Euler (0, 0, -balaImgAngulo));
            bala.GetComponent<Rigidbody2D> ().velocity = direccionBala * balaSpd * Time.deltaTime;

            /*
            GameObject bala = Instantiate(projectile, new Vector3(transform.position.x, transform.position.y, angulo), Quaternion.identity);
            bala.GetComponent<Rigidbody2D> ().velocity = direccionBala;
            */

            /*
            if (enemyPosition.x < transform.position.x)
           {
                GameObject bala = Instantiate (projectile, transform.position, Quaternion.Euler(0, 0, -angulo));
                bala.GetComponent<Rigidbody2D>().velocity = direccionBala;
                //bala.transform.rotation = Quaternion.Euler()
                //bala.transform.rotation.z = angulo;
           }

           else
           {
                GameObject bala = Instantiate (projectile, transform.position, Quaternion.Euler (0, 0, -angulo));
                bala.GetComponent<Rigidbody2D> ().velocity = direccionBala;
                //bala.GetComponent<Rigidbody2D> ().rotation = angulo;
                //Quaternion anguloBala = Quaternion.LookRotation (transform.position, enemyPosition);
                //bala.transform.rotation = anguloBala;
            }
            */
           

            Shootcooldown = timeToShoot;

            audioSource.clip = sonidoAtaque;

            audioSource.Play();

        }
    }
        private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere (transform.position, visualRadius);
    }

    private Vector2 FindClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        Enemy closestEnemy = null;
        Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

        foreach (Enemy currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }

        if (closestEnemy != null)
        {
            Debug.DrawLine (this.transform.position, closestEnemy.transform.position);
            return closestEnemy.transform.position;
        }
        else return transform.position;

        

    }


}
