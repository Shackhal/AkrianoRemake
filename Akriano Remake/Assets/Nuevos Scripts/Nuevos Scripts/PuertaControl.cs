using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaControl : MonoBehaviour
{
    public List<GameObject> Puertas;

    private List<GameObject> Enemigos = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject door in Puertas)
        {
            door.GetComponent<Animator> ().SetTrigger ("Cerrar");
            door.GetComponent<BoxCollider2D> ().enabled = true;
        }



    }

    // Update is called once per frame
    void Update()
    {
        if (Enemigos.Count <= 0)
        {
            foreach (GameObject door in Puertas)
            {
                door.GetComponent<Animator> ().SetTrigger ("Abrir");
                door.GetComponent<BoxCollider2D> ().enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag ("Enemy"))
        {
            Enemigos.Add (collision.gameObject);
            Debug.Log ("Enemigo agregago");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag ("Enemy"))
        {
            Enemigos.Remove (collision.gameObject);
            Debug.Log ("Enemigo muerto");
        }
    }
}
