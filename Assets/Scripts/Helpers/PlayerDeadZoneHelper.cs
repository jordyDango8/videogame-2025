using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneHelper : MonoBehaviour
{
    [SerializeField]
    Transform target;

    void Update()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collided with: " + other.name);
        other.SendMessage("Die");
    }
}
