using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalToBeRescuedHelper : MonoBehaviour
{
    [SerializeField]
    EnumManager.AnimalsNames myAnimalName;

    Animator animator;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(EnumManager.Tags.Player.ToString()))
        {
            switch (myAnimalName)
            {
                case EnumManager.AnimalsNames.OrangeCat:
                    animator.Play(EnumManager.Animations.orangeCatBeRescued.ToString());
                    break;
                case EnumManager.AnimalsNames.WhiteCat:
                    animator.Play(EnumManager.Animations.whiteCatBeRescued.ToString());
                    break;
                default:
                    Debug.LogWarning("Animal name not found");
                    break;
            }
            EventsManager.CallOnAnimalRescued(myAnimalName);
        }
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        animator = GetComponent<Animator>();
    }
}
