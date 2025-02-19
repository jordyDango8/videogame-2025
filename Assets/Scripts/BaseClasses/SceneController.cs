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

    protected PlayerData playerData;

    [SerializeField]
    Image gameOverScreen;

    [SerializeField]
    TextMeshProUGUI gameOverTMP;

    [SerializeField]
    float waitToChangeScene = 3.0f;

    void Start()
    {
        audioManager.Play(EnumManager.Audio.level1);
        waitToChangeScene = 0f; // ForTesting
    }

    void GameOver(bool _hasWin)
    //void GameOver()
    {
        gameOverScreen.enabled = true;
        if (_hasWin)
        {
            //Debug.Log("win");            
            gameOverScreen.sprite = spritesManager.winScreen;
            ChangeScene(EnumManager.Scenes.TowerDefenseLevel1);
        }
        else
        {
            //Debug.Log("lose");
            gameOverScreen.sprite = spritesManager.loseScreen;
            ChangeScene(EnumManager.Scenes.EndlessRunnerLevel1);
        }
    }

    void ChangeScene(EnumManager.Scenes _scene)
    {
        StartCoroutine(ChangeSceneCoroutine(_scene));
    }

    IEnumerator ChangeSceneCoroutine(EnumManager.Scenes _scene)
    {
        yield return new WaitForSeconds(waitToChangeScene);
        SceneManager.LoadScene(_scene.ToString());
    }

    void OnEnable()
    {
        audioManager = AudioManager.audioManager;
        spritesManager = SpritesManager.spritesManager;
        playerData = PlayerData.playerData;

        EventsManager.onGameOver += GameOver;
    }

    void OnDisable()
    {
        EventsManager.onGameOver -= GameOver;
    }
}
