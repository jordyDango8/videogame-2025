using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI livesTMP;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    internal void UpdateLives(float _lives)
    {
        livesTMP.text = "lives: " + _lives.ToString();
    }
}
