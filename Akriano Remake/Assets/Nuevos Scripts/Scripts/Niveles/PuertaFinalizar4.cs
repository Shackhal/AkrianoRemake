using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaFinalizar4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //se le asignara un collider a la puerta
        gameObject.AddComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Mundo 5", LoadSceneMode.Single);
        }
    }
}
