using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguir_Enemigo : MonoBehaviour
{
    // Start is called before the first frame update
    float velocidad = 3.0f;

    Transform objetivo;
    void Start()
    {
        objetivo = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, objetivo.position, velocidad * Time.deltaTime);
    }
}
