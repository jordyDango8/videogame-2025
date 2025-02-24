using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPortalBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject ally;

    [SerializeField]
    Transform spawnPoint;

    void OnMouseDown()
    {
        Debug.Log("Clicked");
        SpawnAlly();
    }

    void SpawnAlly()
    {
        Instantiate(ally, spawnPoint.position, Quaternion.identity);
    }

}
