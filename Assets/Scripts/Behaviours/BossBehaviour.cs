using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class BossBehaviour : MonoBehaviour
{
    AudioManager audioManager;
    EnumManager enumManager;
    PlayerDataManager playerDataManager;
    SpritesManager spritesManager;

    SpriteRenderer mySpriteRenderer;

    [SerializeField]
    BossShadowhHelper bossShadowHelper;

    [SerializeField]
    GameObject minionPrefab;

    [SerializeField]
    Transform[] positionPoints;

    [SerializeField]
    Color gizmosColor;

    [SerializeField]
    float circleRadius;

    [SerializeField]
    EnemyMinionBehaviour[] minions;

    float maxHealt = 100.0f;
    float currentHealth;

    float nextActionCooldownMin = 1.0f;
    float nextActionCooldownMax = 3.0f;

    EnumManager.BossActions action;

    float spawnCooldown = 0.3f;

    int minionsMax = 5;

    void Start()
    {
        SetSprite();
        currentHealth = maxHealt;
        SpawnMinions();
        StartCoroutine(ChooseAction());
    }
    void SetSprite()
    {
        if (playerDataManager.GetRescuedAnimals()[0] == EnumManager.AnimalsNames.OrangeCat)
        {
            mySpriteRenderer.sprite = spritesManager.whiteCatNormal;
        }
        else
        {
            mySpriteRenderer.sprite = spritesManager.orangeCatNormal;
        }
    }

    IEnumerator ChooseAction()
    {
        yield return new WaitForSeconds(Random.Range(nextActionCooldownMin, nextActionCooldownMax));
        action = enumManager.GetRandomEnumValue<EnumManager.BossActions>();
        //action = EnumManager.BossActions.move; // for testing
        //action = EnumManager.BossActions.attack; // for testing
        //action = EnumManager.BossActions.spawnMinions; // for testing
        CallAction();
        //Debug.Log($"current action {action}");

        // should be after finishing current action
        StartCoroutine(ChooseAction());
    }

    void CallAction()
    {
        switch (action)
        {
            case EnumManager.BossActions.move:
                Move();
                break;
            case EnumManager.BossActions.attack:
                Attack();
                break;
            case EnumManager.BossActions.spawnMinions:
                SpawnMinions();
                break;
            default:
                Debug.LogWarning($"action {action} not found");
                break;
        }
    }

    void Move()
    {
        //Debug.Log("move");
        transform.position = positionPoints[Random.Range(0, positionPoints.Length)].position;
    }

    void SpawnMinions()
    {
        StartCoroutine(SpawnMinionsCoroutine());
    }

    IEnumerator SpawnMinionsCoroutine()
    {
        for (int i = 0; i < minionsMax; i++)
        {
            if (minions[i].GetCurrentState() == EnumManager.enemyMinionStates.dead)
            {
                minions[i].Initialize(this, i);
                yield return new WaitForSeconds(spawnCooldown);
            }
            else
            {
                yield return new WaitForSeconds(0);
            }
        }
    }

    void Attack()
    {
        //Debug.Log("Attack");        
        for (int i = 0; i < minionsMax; i++)
        {
            if (minions[i].GetCurrentState() == EnumManager.enemyMinionStates.orbiting)
            {
                minions[i].Attack();
                break;
            }
        }
    }

    internal void TakeDamage(float _amount)
    {
        //Debug.Log($"{gameObject.name} take damage");
        audioManager.Play(EnumManager.Audio.unstitch);
        currentHealth -= _amount;
        if (currentHealth <= 0)
        {
            //Debug.Log("win");
            EventsManager.CallOnGameOver(true);
            Destroy(gameObject);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = gizmosColor;
        Gizmos.DrawWireSphere(transform.position, circleRadius);
    }

    void OnEnable()
    {
        audioManager = AudioManager.audioManager;
        enumManager = EnumManager.enumManager;
        playerDataManager = PlayerDataManager.playerDataManager;
        spritesManager = SpritesManager.spritesManager;

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
    #endregion

}
