using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    AudioManager audioManager;
    PlayerDataManager playerDataManager;
    SpritesManager spritesManager;

    TowerHealthHelper towerHealthHelper;

    SpriteRenderer mySpriteRenderer;

    float maxHealt = 100.0f;
    float currentHealth = 0;

    float speed = 1.0f;

    Vector3 movementTarget;

    float smoothTime = 0.2f;

    void Start()
    {
        SetSprite();
        currentHealth = maxHealt;
        movementTarget = transform.position;
    }

    void SetSprite()
    {
        if (playerDataManager.GetRescuedAnimals()[0] == EnumManager.AnimalsNames.OrangeCat)
        {
            mySpriteRenderer.sprite = spritesManager.orangeCatNormal;
        }
        else
        {
            mySpriteRenderer.sprite = spritesManager.whiteCatNormal;
        }
    }

    void Update()
    {
        if (transform.position != movementTarget)
        {
            Vector3 velocity = Vector3.one * speed;
            transform.position = Vector3.SmoothDamp(transform.position, movementTarget, ref velocity, smoothTime);
        }
    }

    internal void TakeDamage(float _amount)
    {
        //Debug.Log($"{gameObject.name} take {_amount} damage");
        audioManager.Play(EnumManager.Audio.unstitch);
        currentHealth -= _amount;
        if (currentHealth < 0)
        {
            //Debug.Log("game over");
            EventsManager.CallOnGameOver(false);
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        audioManager = AudioManager.audioManager;
        playerDataManager = PlayerDataManager.playerDataManager;
        spritesManager = SpritesManager.spritesManager;

        towerHealthHelper = GetComponent<TowerHealthHelper>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    #region getters & setters
    internal float GetMaxHealth()
    {
        return maxHealt;
    }

    internal float GetCurrentHealth()
    {
        return currentHealth;
    }

    internal void SetMovementTarget(Vector3 _newTarget)
    {
        movementTarget = _newTarget;
    }
    #endregion
}
