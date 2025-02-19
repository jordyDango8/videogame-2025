using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    internal static PlayerData playerData;

    int stars;

    List<EnumManager.AnimalsNames> rescuedAnimals = new List<EnumManager.AnimalsNames>();

    void Awake()
    {
        if (playerData == null)
        {
            playerData = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
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