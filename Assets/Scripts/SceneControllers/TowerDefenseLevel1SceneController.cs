using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class TowerDefenseLevel1SceneController : SceneController
{
    [SerializeField]
    SpriteRenderer tower;

    [SerializeField]
    SpriteRenderer boss;

    void Start()
    {
        SetTowerAndBossSprite();
    }

    void SetTowerAndBossSprite()
    {
        Debug.Log($"rescued was {playerData.GetRescuedAnimals()[0]}");
        if (playerData.GetRescuedAnimals()[0] == EnumManager.AnimalsNames.OrangeCat)
        {
            //Boss.sprite = Resources.Load<Sprite>("Sprites/Boss");
            tower.sprite = SpritesManager.spritesManager.orangeCatNormal;
            boss.sprite = SpritesManager.spritesManager.whiteCatCorrupted;
        }
        else
        {
            tower.sprite = SpritesManager.spritesManager.whiteCatNormal;
            boss.sprite = SpritesManager.spritesManager.orangeCatCorrupted;
        }
    }

}
