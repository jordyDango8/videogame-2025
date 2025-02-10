using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsController : MonoBehaviour
{
    /*
    [SerializeField]
    CloudBehaviour[] clouds;

    [SerializeField]
    Transform player;

    float offsetX = 30.0f;

    void Start()
    {
        PrepareScenario();
        StartCoroutine(AppearPlanet());
    }

    void PrepareScenario()
    {
        DisappearAll();
        AppearAtStart();

    }

    void AppearAtStart()
    {
        // how many planets
        int initialPlanets = Random.Range(initialPlanetsMin, initialPlanetsMax);
        for (int i = 0; i < initialPlanets; i++)
        {
            int planetIndex = Random.Range(0, planets.Length);
            planets[planetIndex].Appear();
            float newPosX = Random.Range(starPosMinX, starPosMaxX);
            float newPosY = Random.Range(starPosMinY, starPosMaxY);
            Vector3 newPos = new Vector3(player.position.x + newPosX, newPosY, 0);
            planets[planetIndex].ChangePosition(newPos);
        }
    }

    IEnumerator AppearPlanet()
    {
        // pick random planet
        PlanetBehaviour planetTemp = planets[Random.Range(0, planets.Length)];

        int tries = 0;
        // while enabled
        while (planetTemp.GetState() && tries < 30)
        {
            // pick another
            planetTemp = planets[Random.Range(0, planets.Length)];
            tries += 1;
        }
        // appear the desabled
        planetTemp.Appear();
        float newPosX = Random.Range(starPosMinX, starPosMaxX);
        float newPosY = Random.Range(starPosMinY, starPosMaxY);
        planetTemp.ChangePosition(new Vector3(player.position.x + newPosX + offsetX, newPosY, 0));
        yield return new WaitForSeconds(Random.Range(waitBeforeAppearPlanetMin, waitBeforeAppearPlanetMax));
        StartCoroutine(AppearPlanet());
    }


    void DisappearAll()
    {
        foreach (PlanetBehaviour planet in planets)
        {
            planet.Dissapear();
        }
    }
    */
}
