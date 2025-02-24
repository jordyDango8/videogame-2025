using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionBehaviour : MonoBehaviour
{
    [SerializeField]
    BossBehaviour boss;

    Transform centerPoint; // El punto alrededor del cual orbitará el objeto
    [SerializeField]
    float orbitSpeed;
    [SerializeField]
    float orbitRadius;

    void Start()
    {
        centerPoint = boss.transform;
    }

    void Update()
    {
        Orbit();
    }

    void Orbit()
    {
        if (centerPoint != null)
        {
            // Calcular la posición de la órbita
            float angle = Time.time * orbitSpeed;
            float x = Mathf.Cos(angle) * orbitRadius;
            float y = Mathf.Sin(angle) * orbitRadius;

            // Actualizar la posición del objeto
            transform.position = new Vector3(centerPoint.position.x + x, centerPoint.position.y + y, transform.position.z);
        }
    }
}
