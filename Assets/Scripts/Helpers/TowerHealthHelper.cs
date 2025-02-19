using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerHealthHelper : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer damageShadowBar;


    float minHealth = 0;
    [SerializeField]
    float currentHealth;
    float maxHealth = 100;

    float damageShadowBarMinHeight = 0.0f;
    float damageShadowBarMaxHeight = 16.5f;

    void Start()
    {
        currentHealth = maxHealth;

        // shadow size must start at 0
        damageShadowBar.size = new Vector2(damageShadowBar.size.x, 0);
    }

    void Update()
    {
        UpdateDamegeShadowBar();
    }

    void UpdateDamegeShadowBar()
    {
        float curentDamage = (maxHealth - currentHealth);
        float healthPercentage = curentDamage / maxHealth; // to make it from 0 to 1
        float newHeight = Mathf.Lerp(damageShadowBarMinHeight, damageShadowBarMaxHeight, healthPercentage);
        damageShadowBar.size = new Vector2(damageShadowBar.size.x, newHeight);
    }
}
