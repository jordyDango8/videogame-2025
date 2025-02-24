using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    [SerializeField]
    Color gizmosColor;

    [SerializeField]
    float circleRadius;


    void Start()
    {

    }

    void Update()
    {

    }

    void OnDrawGizmos()
    {
        Gizmos.color = gizmosColor;
        Gizmos.DrawWireSphere(transform.position, circleRadius);
    }
}
