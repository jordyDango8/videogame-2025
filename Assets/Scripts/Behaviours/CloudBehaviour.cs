using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviour : MonoBehaviour
{
    float offsetX = 9.6f;
    int clouds = 4;

    internal void Dissapear()
    {
        //Debug.Log($"{gameObject.name} dissapeared");

        // appear in front
        Vector3 newPos = new Vector3
        (
            transform.position.x + (offsetX * clouds),
            transform.position.y,
            transform.position.z
        );
        ChangePosition(newPos);
    }

    internal void ChangePosition(Vector3 _newPosition)
    {
        transform.position = _newPosition;
    }


}
