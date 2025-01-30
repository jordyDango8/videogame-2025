using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBehaviour : MonoBehaviour
{
    SpriteRenderer mySpriteRenderer;

    [SerializeField]
    Transform target;

    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

    }

    internal void Appear()
    {
        EnDisSpriteRenderer(true);
        ChangePosition(target.position); // in player's position
    }

    void EnDisSpriteRenderer(bool _newState)
    {
        mySpriteRenderer.enabled = _newState;
    }

    void ChangePosition(Vector3 _newPosition)
    {
        transform.position = _newPosition;
    }
}
