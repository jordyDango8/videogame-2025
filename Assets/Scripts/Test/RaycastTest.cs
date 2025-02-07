using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    /*
    [SerializeField]
    Transform groundedRayOrigin;

    [SerializeField]

    LayerMask groundedRayLayerMask;

    float groundedRayDistance = 0.5f;

    Vector3 groundedRayDirection = Vector3.down;

    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(groundedRayOrigin.position, groundedRayDirection * groundedRayDistance, Color.blue);
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast
        (
            groundedRayOrigin.position,
            groundedRayDirection,
            out hit,
            groundedRayDistance,
            groundedRayLayerMask
        ))
        {
            //Debug.DrawRay(groundedRayOrigin.position, groundedRayDirection * groundedRayDistance, Color.red);
            Debug.Log("Did Hit");
        }
        else
        {
            //Debug.DrawRay(groundedRayOrigin.position, groundedRayDirection * groundedRayDistance, Color.green);
            Debug.Log("Did not Hit");
        }
    }
    */

    void FixedUpdate()
    {
        // Cast a ray straight down.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

        // If it hits something...
        if (hit)
        {
            Debug.Log("hit");
        }
        else
        {
            Debug.Log("no hit");
        }
    }
}
