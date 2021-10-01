using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguir : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Transform objetivo;
    float t_max = 0.5f;
    float t = 0;

    void Start()
    {
        speed = 1.0f;
        objetivo = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(objetivo.position, transform.position) > 1.05f)
            transform.position = Vector2.MoveTowards(transform.position, objetivo.position, speed * Time.deltaTime);

        if (t < t_max)
        {
            t += Time.deltaTime;
        }
        else
        {
            GameObject bala = new GameObject();
            bala.transform.position = transform.position;
            bala.AddComponent<Rigidbody2D>().gravityScale = 0;
            bala.AddComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
            bala.GetComponent<Rigidbody2D>().AddForce((objetivo.position - transform.position).normalized * 300.0f);
            t = 0;

        }
    }
}
