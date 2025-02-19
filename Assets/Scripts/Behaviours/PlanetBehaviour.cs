using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBehaviour : MonoBehaviour
{
    SpriteRenderer mySpriteRenderer;

    Transform player;

    internal void Appear()
    {
        EnDisSpriteRenderer(true);
        //ChangePosition(player.position); // in player's position
    }

    internal void Dissapear()
    {
        //Debug.Log($"{gameObject.name} dissapeared");
        EnDisSpriteRenderer(false);
    }

    void EnDisSpriteRenderer(bool _newState)
    {
        mySpriteRenderer.enabled = _newState;
    }

    internal void ChangePosition(Vector3 _newPosition)
    {
        transform.position = _newPosition;
    }

    #region Getters&Setters
    internal bool GetState()
    {
        return mySpriteRenderer.enabled;
    }
    #endregion

    void OnEnable()
    {
        //Debug.Log("onEnable");
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
}
