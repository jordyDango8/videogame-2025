using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class positionHelper : MonoBehaviour
{
    [SerializeField]
    TowerBehaviour towerBehaviour;

    void OnMouseDown()
    {
        towerBehaviour.SetMovementTarget(transform.position);
    }
}