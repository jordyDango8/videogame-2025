using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class EventsManager
{
    //internal static EventsManager eventsManager;

    internal delegate void OnGameOver(bool _hasWin);
    internal static event OnGameOver onGameOver;

    internal delegate void OnAnimalRescued(EnumManager.AnimalsNames _animalName);
    internal static event OnAnimalRescued onAnimalRescued;

    //internal static event UnityAction OnGameOver;
    //public static void onGameOver() => OnGameOver?.Invoke();

    //public static void onGameOver() => OnGameOver?.Invoke();

    /*
    void Awake()
    {
        if (eventsManager == null)
        {
            eventsManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    */

    internal static void CallOnGameOver(bool _hasWin)
    {
        onGameOver(_hasWin);
    }

    internal static void CallOnAnimalRescued(EnumManager.AnimalsNames _animalName)
    {
        onAnimalRescued(_animalName);
    }
}
