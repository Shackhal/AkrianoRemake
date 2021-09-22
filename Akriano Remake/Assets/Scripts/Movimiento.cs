using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movimiento : MonoBehaviour
{
    public float speed = 4f;

    Animator anim;
    Rigidbody2D rb2d;
    Vector2 mov;

    public Image Corazon;
    public int CantDeCorazon;
    public RectTransform PosicionPrimerCorazon;
    public Canvas MyCanvas;
    public int OffSet;

    void Start()
    {

        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

        Transform PosCorazon = PosicionPrimerCorazon;

        for (int i = 0; i < CantDeCorazon; i++)
        {
            Image NewCorazon = Instantiate(Corazon, PosCorazon.position, Quaternion.identity);
            NewCorazon.transform.parent = MyCanvas.transform;
            PosCorazon.position = new Vector2(PosCorazon.position.x + OffSet, PosCorazon.position.y);
        }

    }

    // Update is called once per frame
    void Update()
    {
        mov = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
            );


        /*Vector3 mov = new Vector3(
           Input.GetAxisRaw("Horizontal"),
           Input.GetAxisRaw("Vertical"), 0
           );

        transform.position = Vector3.MoveTowards(
            transform.position,
            transform.position + mov,
            speed * Time.deltaTime
            );*/

        if (mov != Vector2.zero) {
            anim.SetFloat("MovX", mov.x);
            anim.SetFloat("MovY", mov.y);
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        /*if (Input.GetKeyUp (KeyCode.A))
        {
            anim.SetTrigger("Attack");
        }*/

    }

    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + mov * speed * Time.deltaTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            Destroy(MyCanvas.transform.GetChild(CantDeCorazon + 1).gameObject);
            CantDeCorazon -= 1;
            Destroy(collision.gameObject);
        }
    }
}
