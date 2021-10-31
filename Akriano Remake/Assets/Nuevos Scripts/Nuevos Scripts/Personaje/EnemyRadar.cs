using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadar : MonoBehaviour
{

    private GameObject[] multipleEnemys;
    public Transform closestEnemy;
    public bool enemyContact;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        closestEnemy = null;
        enemyContact = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.isTrigger =! true && collision.CompareTag("Enemy")) 
        {
            closestEnemy = getClosestEnemy();
            closestEnemy.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(1, 0.7f, 0, 1);
            enemyContact = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger = !true && collision.CompareTag("Enemy")) 
        {
            enemyContact = false;
            closestEnemy.gameObject.GetComponent<SpriteRenderer>().material.color = Color.white;
            
        }
    }





    public Transform getClosestEnemy() 
    {
        multipleEnemys = GameObject.FindGameObjectsWithTag("Enemy");

        float closestDistance = Mathf.Infinity;
        Transform trans = null;

        foreach (GameObject go in multipleEnemys)
        {
            float currentDistance;
            currentDistance = Vector3.Distance(transform.position, go.transform.position);
            if (closestDistance < currentDistance) 
            {
                closestDistance = currentDistance;
                trans = go.transform;
            }
        }

        return trans;


    }


}
