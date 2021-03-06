using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSeguir : MonoBehaviour
{
    public GameObject follow;

    public Vector2 minCamPos, maxCamPos;

    void FixedUpdate()
    {
        float posX = follow.transform.position.x;
        float posY = follow.transform.position.y;


        transform.position = new Vector3(
            Mathf.Clamp(posX, minCamPos.x, maxCamPos.x), 
            Mathf.Clamp(posY, minCamPos.y, maxCamPos.y),
            transform.position.z);
    }


}
