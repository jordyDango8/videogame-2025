using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;

public class TowerDefenseLevel1SceneController : SceneController
{
    protected override void Start()
    {
        myLevelAudio = EnumManager.Audio.level1TowerDefenseOpening;
        myLoseAudio = EnumManager.Audio.loseBossFight;
        myWinAudio = EnumManager.Audio.winBossFight;
        nextSceneIfLose = EnumManager.Scenes.TowerDefenseLevel1;
        nextSceneIfWin = EnumManager.Scenes.EndlessRunnerLevel1; // meanwhile main menu is created

        StartCoroutine(PlayLevelMusic());
    }

    IEnumerator PlayLevelMusic()
    {
        audioManager.Play(myLevelAudio);
        yield return new WaitForSeconds(audioManager.GetAudioDuration(EnumManager.Audio.level1TowerDefenseOpening));

        audioManager.Stop(myLevelAudio);
        myLevelAudio = EnumManager.Audio.level1TowerDefenseLoop;
        audioManager.Play(myLevelAudio);
    }

}
