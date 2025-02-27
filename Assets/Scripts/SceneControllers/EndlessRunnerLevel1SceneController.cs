using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndlessRunnerSceneController : SceneController
{
    protected override void Start()
    {
        playerDataManager.EraseRescuedAnimals();

        myLevelAudio = EnumManager.Audio.level1EndlessRunner;
        myLoseAudio = EnumManager.Audio.loseEndless;
        myWinAudio = EnumManager.Audio.winEndless;
        //waitToChangeScene = 0f; // ForTesting

        nextSceneIfLose = EnumManager.Scenes.EndlessRunnerLevel1;
        nextSceneIfWin = EnumManager.Scenes.TowerDefenseLevel1;

        base.Start();
    }

}

