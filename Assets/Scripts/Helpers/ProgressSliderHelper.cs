using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressSliderHelper : MonoBehaviour
{
    PlayerDataManager playerDataManager;

    Slider mySlider;

    internal void UpdateSlider()
    {
        mySlider.value = playerDataManager.GetStars();
    }

    void OnEnable()
    {
        playerDataManager = PlayerDataManager.playerDataManager;
        mySlider = GetComponent<Slider>();
    }
}
