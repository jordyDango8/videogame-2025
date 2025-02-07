using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    int stars;

    internal int GetStars()
    {
        return stars;
    }

    internal void SetStars(int _newValue)
    {
        stars = _newValue;
    }
}