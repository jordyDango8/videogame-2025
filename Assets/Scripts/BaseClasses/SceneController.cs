using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    protected AudioManager audioManager;

    protected SpritesManager spritesManager;

    protected PlayerDataManager playerDataManager;

    [SerializeField]
    protected Image gameOverScreen;

    [SerializeField]
    protected TextMeshProUGUI gameOverTMP;

    [SerializeField]
    protected float waitToChangeScene = 3.0f;

    protected EnumManager.Scenes nextSceneIfLose;
    protected EnumManager.Scenes nextSceneIfWin;

    protected EnumManager.Audio myLevelAudio;
    protected EnumManager.Audio myWinAudio;
    protected EnumManager.Audio myLoseAudio;

    protected virtual void Start()
    {
        audioManager.Play(myLevelAudio);
    }

    protected void GameOver(bool _hasWin)
    {
        Debug.Log($"game over {gameObject.name}");
        audioManager.Stop(myLevelAudio);
        gameOverScreen.enabled = true;
        if (_hasWin)
        {
            //Debug.Log("win");    
            audioManager.Play(myWinAudio);
            gameOverScreen.sprite = spritesManager.winScreen;
            ChangeScene(nextSceneIfWin);
            Debug.Log($"next scene {nextSceneIfWin}");
        }
        else
        {
            //Debug.Log("lose");
            audioManager.Play(myLoseAudio);
            gameOverScreen.sprite = spritesManager.loseScreen;
            ChangeScene(nextSceneIfLose);
            Debug.Log($"next scene {nextSceneIfLose}");
        }

    }

    internal void ChangeScene(EnumManager.Scenes _scene)
    {
        StartCoroutine(ChangeSceneCoroutine(_scene));
    }

    IEnumerator ChangeSceneCoroutine(EnumManager.Scenes _scene)
    {
        yield return new WaitForSeconds(waitToChangeScene);
        SceneManager.LoadScene(_scene.ToString());
    }

    protected void OnEnable()
    {
        Debug.Log($"on enable {gameObject.name}");
        audioManager = AudioManager.audioManager;
        Debug.Log($"AudioManager {audioManager} {gameObject.name}");
        spritesManager = SpritesManager.spritesManager;
        playerDataManager = PlayerDataManager.playerDataManager;

        EventsManager.onGameOver += GameOver;
    }

    protected void OnDisable()
    {
        EventsManager.onGameOver -= GameOver;
        audioManager.Stop(myLevelAudio);
    }
}
