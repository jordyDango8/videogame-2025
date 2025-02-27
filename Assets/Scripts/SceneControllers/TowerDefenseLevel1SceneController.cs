using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;

public class TowerDefenseLevel1SceneController : SceneController
{
    [SerializeField]
    SpriteRenderer tower;

    [SerializeField]
    SpriteRenderer boss;

    protected override void Start()
    {
        myLevelAudio = EnumManager.Audio.level1TowerDefenseOpening;
        myLoseAudio = EnumManager.Audio.loseBossFight;
        myWinAudio = EnumManager.Audio.winBossFight;
        nextSceneIfLose = EnumManager.Scenes.TowerDefenseLevel1;
        nextSceneIfWin = EnumManager.Scenes.EndlessRunnerLevel1; // meanwhile main menu is created

        StartCoroutine(PlayLevelMusic());
        SetTowerAndBossSprite();
    }

    IEnumerator PlayLevelMusic()
    {
        audioManager.Play(myLevelAudio);
        yield return new WaitForSeconds(audioManager.GetAudioDuration(EnumManager.Audio.level1TowerDefenseOpening));

        audioManager.Stop(myLevelAudio);
        myLevelAudio = EnumManager.Audio.level1TowerDefenseOpening;
        audioManager.Play(myLevelAudio);
    }

    void SetTowerAndBossSprite()
    {
        Debug.Log($"rescued was {playerDataManager.GetRescuedAnimals()[0]}");
        if (playerDataManager.GetRescuedAnimals()[0] == EnumManager.AnimalsNames.OrangeCat)
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
