using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Vector3 positionToMoveTo;
    public Transform target;

    void Start()
    {
        //x=19.25f;
        //y=10.75f;
        // StartCoroutine(LerpPosition(positionToMoveTo, 1));
    }

    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = target.transform.position;

        while (time < duration)
        {
            target.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        target.transform.position = targetPosition;
    }
}
