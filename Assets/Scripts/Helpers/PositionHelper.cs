using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class positionHelper : MonoBehaviour
{
    //[SerializeField]
    //TowerBehaviour target;

    [SerializeField]
    Transform target;

    void OnMouseDown()
    {
        Debug.Log("$move to {transform.postion}");
        while (target.position != transform.position)
        {
            //target
            //target.position = Lerp(transform.position);
        }
    }
}
