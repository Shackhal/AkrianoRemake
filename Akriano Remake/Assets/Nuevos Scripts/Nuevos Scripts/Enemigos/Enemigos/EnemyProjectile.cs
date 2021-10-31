using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public GameObject projectile;

    public float timeToShoot;
    public float Shootcooldown;

    Transform objetivo;
    Vector3 enemyPosition;

    void Start()
    {
        Shootcooldown = timeToShoot;
        objetivo = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyPosition = FindClosestPlayer();
        Shootcooldown -= Time.deltaTime;



        if (Shootcooldown < 0)
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

            Shootcooldown = timeToShoot;

        }



    }

    private Vector2 FindClosestPlayer()
    {
        float distanceToClosestPlayer = Mathf.Infinity;
        Player closestPlayer = null;
        Player[] allplayers = GameObject.FindObjectsOfType<Player>();

        foreach (Player currentPlayer in allplayers)
        {
            float distanceToPlayer = (currentPlayer.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToPlayer < distanceToClosestPlayer)
            {
                distanceToClosestPlayer = distanceToPlayer;
                closestPlayer = currentPlayer;
            }
        }

        Debug.DrawLine(this.transform.position, closestPlayer.transform.position);
        return closestPlayer.transform.position;
    }
}
