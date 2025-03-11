using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesManager : MonoBehaviour
{
    internal static SpritesManager spritesManager;

    [SerializeField]
    internal Sprite fox;

    [SerializeField]
    internal Sprite orangeCatNormal;

    [SerializeField]
    internal Sprite orangeCatCorrupted;

    [SerializeField]
    internal Sprite whiteCatNormal;

    [SerializeField]
    internal Sprite whiteCatCorrupted;

    [SerializeField]
    internal Sprite winScreen;

    [SerializeField]
    internal Sprite loseScreen;

    void Awake()
    {
        if (spritesManager == null)
        {
            spritesManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
