using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoAuto : MonoBehaviour
{
    public GameObject projectile;

    public float timeToShoot;
    public float Shootcooldown;
    public float visualRadius;

    Transform objetivo;
    Vector3 enemyPosition;

    void Start()
    {
        Shootcooldown = timeToShoot;
        objetivo = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
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
            GameObject bala = Instantiate(projectile, transform.position, Quaternion.identity);

            if (enemyPosition.x < transform.position.x)
            {
                bala.GetComponent<Rigidbody2D>().velocity = (enemyPosition - transform.position) * new Vector2(1f, 1f);
            }

            else
            {
                bala.GetComponent<Rigidbody2D>().velocity = (enemyPosition - transform.position) * new Vector2 (1f, 1f);
            }

            Shootcooldown = timeToShoot;

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
