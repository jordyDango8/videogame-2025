using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundDeadZoneHelper : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    float offsetX = 20;

    void Update()
    {
        transform.position = new Vector3(target.position.x - offsetX, transform.position.y, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("collided with: " + other.name);
        if (other.CompareTag(EnumManager.Tags.Planet.ToString()))
        {
            other.GetComponent<PlanetBehaviour>().Dissapear();
        }
        if (other.CompareTag(EnumManager.Tags.Cloud.ToString()))
        {
            other.GetComponent<CloudBehaviour>().Dissapear();
        }
    }
}
