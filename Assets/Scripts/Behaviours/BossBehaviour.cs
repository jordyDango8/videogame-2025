using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class BossBehaviour : MonoBehaviour
{
    EnumManager enumManager;

    [SerializeField]
    GameObject minionPrefab;

    [SerializeField]
    Transform[] positionPoints;

    [SerializeField]
    Color gizmosColor;

    [SerializeField]
    float circleRadius;

    List<MinionBehaviour> minions = new List<MinionBehaviour>();

    float maxHealt = 100.0f;
    float currentHealth;

    float nextActionCooldownMin = 1.0f;
    float nextActionCooldownMax = 3.0f;

    EnumManager.BossActions action;

    void Start()
    {
        for (int i = 0; i <= 4; i++)
        {
            SpawnMinion();
        }
        currentHealth = maxHealt;
        StartCoroutine(ChooseAction());
    }

    void SpawnMinion()
    {
        GameObject minionTemp = Instantiate(minionPrefab, transform.position, Quaternion.identity);
        MinionBehaviour minionBehaviour = minionTemp.GetComponent<MinionBehaviour>();
        minionBehaviour.Initialize(this, minions.Count);
        minions.Add(minionBehaviour);
    }

    IEnumerator ChooseAction()
    {
        yield return new WaitForSeconds(Random.Range(nextActionCooldownMin, nextActionCooldownMax));
        //action = enumManager.GetRandomEnumValue<EnumManager.BossActions>();
        //action = EnumManager.BossActions.move; // for testing
        action = EnumManager.BossActions.attack; // for testing
        CallAction();
        Debug.Log($"current action {action}");

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
            default:
                Debug.LogWarning($"action {action} not found");
                break;
        }
    }

    void Move()
    {
        Debug.Log("move");
        transform.position = positionPoints[Random.Range(0, positionPoints.Length)].position;
    }

    void Attack()
    {
        Debug.Log("Attack");
        // quitar un minion
        minions[0].Attack();
        minions.RemoveAt(0);
    }

    internal void TakeDamage(float _amount)
    {
        Debug.Log($"{gameObject.name} take damage");
        currentHealth -= _amount;
        if (currentHealth <= 0)
        {
            Debug.Log("win");
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = gizmosColor;
        Gizmos.DrawWireSphere(transform.position, circleRadius);
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

    void OnEnable()
    {
        enumManager = EnumManager.enumManager;
    }

}
