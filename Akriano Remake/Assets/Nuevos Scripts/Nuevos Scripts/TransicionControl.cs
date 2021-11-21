using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransicionControl : MonoBehaviour
{
    CameraController cam;

    public Vector2 changeCamPos;
    public Vector3 movePlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraController> ();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cam.camPos = new Vector3 (cam.transform.position.x + changeCamPos.x, cam.transform.position.y + changeCamPos.y, cam.transform.position.z);
            collision.gameObject.transform.position += movePlayer;
            collision.gameObject.GetComponent<Player> ().target = collision.gameObject.transform.position;
        }
    }
}
