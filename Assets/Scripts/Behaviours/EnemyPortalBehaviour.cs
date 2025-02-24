using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class EnemyPortalBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;

    [SerializeField]
    Transform spawnPoint;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(5f);
        Instantiate(enemy, spawnPoint.position, Quaternion.identity);
        StartCoroutine(SpawnEnemy());
    }
}
