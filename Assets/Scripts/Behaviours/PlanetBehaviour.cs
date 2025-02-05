using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBehaviour : MonoBehaviour
{
    SpriteRenderer mySpriteRenderer;

    Transform player;

    void Start()
    {

    }

    void Update()
    {

    }

    internal void Appear()
    {
        EnDisSpriteRenderer(true);
        //ChangePosition(player.position); // in player's position
    }

    void EnDisSpriteRenderer(bool _newState)
    {
        mySpriteRenderer.enabled = _newState;
    }

    internal void ChangePosition(Vector3 _newPosition)
    {
        transform.position = _newPosition;
    }

    void OnEnable()
    {
        //Debug.Log("onEnable");
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
}
