using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    internal static PlayerDataManager playerDataManager;

    int stars;

    List<EnumManager.AnimalsNames> rescuedAnimals = new List<EnumManager.AnimalsNames>();

    void Awake()
    {
        if (playerDataManager == null)
        {
            playerDataManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        SetRescuedAnimals(EnumManager.AnimalsNames.OrangeCat); //for testing
    }

    internal int GetStars()
    {
        return stars;
    }

    internal void SetStars(int _newValue)
    {
        stars = _newValue;
    }

    internal List<EnumManager.AnimalsNames> GetRescuedAnimals()
    {
        return rescuedAnimals;
    }

    internal void SetRescuedAnimals(EnumManager.AnimalsNames _newAnimalName)
    {
        //Debug.Log($"rescued {_newAnimalName}");
        rescuedAnimals.Add(_newAnimalName);
    }

    void OnEnable()
    {
        EventsManager.onAnimalRescued += SetRescuedAnimals;
    }

    void OnDisable()
    {
        EventsManager.onAnimalRescued -= SetRescuedAnimals;
    }
}