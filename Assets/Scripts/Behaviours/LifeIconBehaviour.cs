using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeIconBehaviour : MonoBehaviour
{
    Image myImage;

    void Start()
    {
        myImage = GetComponent<Image>();
    }

    internal void Enable(bool _newState)
    {
        myImage.enabled = _newState;
    }
}
