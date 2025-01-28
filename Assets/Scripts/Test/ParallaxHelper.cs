using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxHelper : MonoBehaviour
{
    Vector3 startPos;

    float maxSpeed = 11; //min layer + 1

    float myParallaxSpeed = 0;
    
    void Start()
    {
        startPos = transform.position;    
        myParallaxSpeed = maxSpeed + GetComponent<SpriteRenderer>().sortingOrder;
        Debug.Log("I'm " + gameObject.name + " " + "my parallax speed is " + myParallaxSpeed);
    }

    
    void Update()
    {
        Move();    
    }

    void Move()
    {
        //the farther, the slowest
        // layer -1     3 = max + layer
        // layer -2     2 = max + layer
        // layer -3     1 = max + layer        
        transform.position -= new Vector3(myParallaxSpeed / 100f, 0, 0);
    }
}
