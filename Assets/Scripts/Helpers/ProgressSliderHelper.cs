using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressSliderHelper : MonoBehaviour
{
    Slider mySlider;

    internal void UpdateSlider()
    {
        mySlider.value = FindObjectOfType<PlayerData>().GetStars();
    }

    void OnEnable()
    {
        mySlider = GetComponent<Slider>();
    }
}
