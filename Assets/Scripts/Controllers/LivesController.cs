using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour
{
    [SerializeField]
    LifeIconBehaviour[] lives;

    int livesMax = 3;
    int livesIndex = 0;

    void Start()
    {
        livesIndex = livesMax - 1;
    }

    internal void TakeDamage()
    {
        lives[livesIndex].Enable(false);
        livesIndex -= 1;
    }
}
