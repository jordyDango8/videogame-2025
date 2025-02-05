using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplaySceneController : MonoBehaviour
{
    void GameOver(bool _hasWin)
    //void GameOver()
    {
        if (_hasWin)
        {
            Debug.Log("win");
        }
        else
        {
            Debug.Log("lose");
        }
        SceneManager.LoadScene(0);
    }

    void OnEnable()
    {
        EventsManager.onGameOver += GameOver;
    }

    void OnDisable()
    {
        EventsManager.onGameOver -= GameOver;
    }
}
