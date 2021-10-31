using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoAuto : MonoBehaviour
{
    public GameObject projectile;

    public float timeToShoot;
    public float Shootcooldown;

    Transform objetivo;
    Vector3 enemyPosition;

    Vector3 BossPosition;

<<<<<<< HEAD
    
<<<<<<< HEAD
=======
    Vector2 enemyPosition;
>>>>>>> parent of cb7e1d5 (Mejorado)
=======
    Vector3 LargePosition;
>>>>>>> parent of cc34bc0 (Merge branch 'main' of https://github.com/Shackhal/AkrianoRemake)
=======
>>>>>>> parent of 9ba1fea (otro)

    void Start()
    {
        Shootcooldown = timeToShoot;
        objetivo = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
        objetivo = GameObject.FindGameObjectWithTag("Boss").GetComponent<Transform>();
<<<<<<< HEAD
        
<<<<<<< HEAD
=======
>>>>>>> parent of cb7e1d5 (Mejorado)
=======
        objetivo = GameObject.FindGameObjectWithTag("EnemyDistance").GetComponent<Transform>();
>>>>>>> parent of cc34bc0 (Merge branch 'main' of https://github.com/Shackhal/AkrianoRemake)
=======
>>>>>>> parent of 9ba1fea (otro)
    }

    // Update is called once per frame
    void Update()
    {
        enemyPosition = FindClosestEnemy();
        BossPosition = FindClosestBoss();
<<<<<<< HEAD
        
<<<<<<< HEAD
=======
>>>>>>> parent of cb7e1d5 (Mejorado)
=======
        LargePosition = FindClosestEnemyDistance();
>>>>>>> parent of cc34bc0 (Merge branch 'main' of https://github.com/Shackhal/AkrianoRemake)
=======
>>>>>>> parent of 9ba1fea (otro)
        Shootcooldown -= Time.deltaTime;



        if (Shootcooldown < 0)
        {
            {
                GameObject bala = Instantiate(projectile, transform.position, Quaternion.identity);

                if (enemyPosition.x < transform.position.x)
                {
                    bala.GetComponent<Rigidbody2D>().velocity = (enemyPosition - transform.position) * new Vector2(1f, 1f);
                }

                else
                {
                    bala.GetComponent<Rigidbody2D>().velocity = (enemyPosition - transform.position) * new Vector2(1f, 1f);
                }


            }
            {
                GameObject bala = Instantiate(projectile, transform.position, Quaternion.identity);

                if (BossPosition.x < transform.position.x)
                {
                    bala.GetComponent<Rigidbody2D>().velocity = (BossPosition - transform.position) * new Vector2(1f, 1f);
                }

                else
                {
                    bala.GetComponent<Rigidbody2D>().velocity = (BossPosition - transform.position) * new Vector2(1f, 1f);
                }

                
            }
            {
                GameObject bala = Instantiate(projectile, transform.position, Quaternion.identity);

                if (LargePosition.x < transform.position.x)
                {
                    bala.GetComponent<Rigidbody2D>().velocity = (LargePosition - transform.position) * new Vector2(1f, 1f);
                }

                else
                {
                    bala.GetComponent<Rigidbody2D>().velocity = (LargePosition - transform.position) * new Vector2(1f, 1f);
                }
            }


            Shootcooldown = timeToShoot;

        }

        /*if (Shootcooldown < 0)
        {
            GameObject bala = Instantiate(projectile, transform.position, Quaternion.identity);

            if (BossPosition.x < transform.position.x)
            {
                bala.GetComponent<Rigidbody2D>().velocity = (BossPosition - transform.position) * new Vector2(1f, 1f);
            }

            else
            {
                bala.GetComponent<Rigidbody2D>().velocity = (BossPosition - transform.position) * new Vector2(1f, 1f);
            }

            Shootcooldown = timeToShoot;

        }*/




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

        Debug.DrawLine(this.transform.position, closestEnemy.transform.position);
        return closestEnemy.transform.position;
    }

    private Vector2 FindClosestBoss()
    {
        float distanceToClosestBoss = Mathf.Infinity;
        Boss closestBoss = null;
        Boss[] allBosses = GameObject.FindObjectsOfType<Boss>();

        foreach (Boss currentBoss in allBosses)
        {
            float distanceToBoss = (currentBoss.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToBoss < distanceToClosestBoss)
            {
                distanceToClosestBoss = distanceToBoss;
                closestBoss = currentBoss;
            }
        }

        Debug.DrawLine(this.transform.position, closestBoss.transform.position);
        return closestBoss.transform.position;
    }

    private Vector2 FindClosestEnemyDistance()
    {
        float distanceToClosestEnemyDistance = Mathf.Infinity;
        EnemyDistance closestEnemyDistance = null;
        EnemyDistance[] allEnemyDistances = GameObject.FindObjectsOfType<EnemyDistance>();

        foreach (EnemyDistance currentEnemyDistance in allEnemyDistances)
        {
            float distanceToEnemyDistance = (currentEnemyDistance.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemyDistance < distanceToClosestEnemyDistance)
            {
                distanceToClosestEnemyDistance = distanceToEnemyDistance;
                closestEnemyDistance = currentEnemyDistance;
            }
        }

        Debug.DrawLine(this.transform.position, closestEnemyDistance.transform.position);
        return closestEnemyDistance.transform.position;
    }






}
