using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalToBeRescuedHelper : MonoBehaviour
{
    [SerializeField]
    EnumManager.AnimalsNames myAnimalName;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(EnumManager.Tags.Player.ToString()))
        {
            EventsManager.CallOnAnimalRescued(myAnimalName);
            Destroy(gameObject);
        }
    }
}
