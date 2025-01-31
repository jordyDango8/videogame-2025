using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPSHelper : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI FPSTMP;
    private float deltaTime = 0.0f;

    void Update()
    {
        // Calculate the FPS
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        int fps = (int)(1f / deltaTime);
        FPSTMP.text = ("FPS: " + fps.ToString());

        //Application.targetFrameRate = 60;

        /* if (SystemInfo.batteryLevel < 0.2f) // Low battery
        {
            Application.targetFrameRate = 30;
        }
        else
        {
            Application.targetFrameRate = 60;
        } */
    }

    /* void OnGUI()
    {
        // Display the FPS on the screen
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.} FPS", fps);
        GUI.Label(rect, text, style);
    } */
}
