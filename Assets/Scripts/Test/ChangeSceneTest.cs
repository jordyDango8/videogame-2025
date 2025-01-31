using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneTest : MonoBehaviour
{
    public void ChangeScene(int _sceneIndex)
    {
        Debug.Log("change scene");
        switch (_sceneIndex)
        {
            case 0:
                SceneManager.LoadScene("WithoutParentsTest");
                break;
            case 1:
                SceneManager.LoadScene("WithParentsTest");
                break;
            case 2:
                SceneManager.LoadScene("Test");
                break;
            default:
                SceneManager.LoadScene("SampleScene");
                break;
        }
    }
}
