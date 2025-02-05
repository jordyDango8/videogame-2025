using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehaviour : MonoBehaviour
{
    //EventsManager eventsManager;    

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collided with: " + other.name);
        //if (EventsManager.onGameOver != null)
        {
            //EventsManager.onGameOver(true); check and solve this error
            EventsManager.CallOnGameOver(true);
        }

    }

    void OnEnable()
    {
        //eventsManager = EventsManager.eventsManager;
    }
}
