using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerHealthHelper : MonoBehaviour
{
    PlayerDataManager playerDataManager;

    [SerializeField]
    Sprite orangeCatCorrupted;

    [SerializeField]
    Sprite whiteCatCorrupted;

    [SerializeField]
    SpriteRenderer damageShadowBar;

    [SerializeField]
    TowerBehaviour towerBehaviour;

    [SerializeField]
    SpriteRenderer shadowSpriteRenderer;

    float damageShadowBarMinHeight = 0.0f;
    float damageShadowBarMaxHeight = 16.5f;

    void Start()
    {
        SetSprite();
        // shadow size must start at 0
        damageShadowBar.size = new Vector2(damageShadowBar.size.x, 0);
    }

    void Update()
    {
        UpdateDamegeShadowBar();
    }

    void UpdateDamegeShadowBar()
    {
        float curentDamage = (towerBehaviour.GetMaxHealth() - towerBehaviour.GetCurrentHealth());
        float healthPercentage = curentDamage / towerBehaviour.GetMaxHealth(); // to make it from 0 to 1
        float newHeight = Mathf.Lerp(damageShadowBarMinHeight, damageShadowBarMaxHeight, healthPercentage);
        damageShadowBar.size = new Vector2(damageShadowBar.size.x, newHeight);
    }

    internal void SetSprite()
    {
        if (playerDataManager.GetRescuedAnimals()[0] == EnumManager.AnimalsNames.OrangeCat)
        {
            shadowSpriteRenderer.sprite = orangeCatCorrupted;
        }
        else
        {
            shadowSpriteRenderer.sprite = whiteCatCorrupted;
        }
    }

    void OnEnable()
    {
        playerDataManager = PlayerDataManager.playerDataManager;
    }
}
