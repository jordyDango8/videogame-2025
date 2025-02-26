using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    float maxHealt = 100.0f;
    float currentHealth = 0;

    void Start()
    {
        currentHealth = maxHealt;
    }

    internal void TakeDamage(float _amount)
    {
        Debug.Log($"{gameObject.name} take {_amount} damage");
        currentHealth -= _amount;
        if (currentHealth < 0)
        {
            Debug.Log("game over");
        }
    }

    #region getters & setters
    internal float GetMaxHealth()
    {
        return maxHealt;
    }

    internal float GetCurrentHealth()
    {
        return currentHealth;
    }
    #endregion
}
