using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector2 initCamPos;
    //public float changeCamPosX;
    //public float changeCamPosY;
    public float smooth;

    public Vector3 camPos;
    //float newCamPosX;
    //float newCamPosY;


    // Start is called before the first frame update
    void Start()
    {
        camPos = new Vector3 (initCamPos.x, initCamPos.y, transform.position.z);
        transform.position = camPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != camPos)
        {
            transform.position = Vector3.Lerp (transform.position, camPos, smooth);
        }
        //Mathf.Clamp (transform.position.x, initCamPos.x, initMaxCamPos.x);


    }
}
