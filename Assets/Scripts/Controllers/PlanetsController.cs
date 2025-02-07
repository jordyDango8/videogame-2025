using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsController : MonoBehaviour
{
    // the planets must appear at begin
    // the planets must desappear when leave from left
    // the planets must appear constantly in the rigth side of the player
    [SerializeField]
    PlanetBehaviour[] planets;

    [SerializeField]
    Transform player;

    int initialPlanetsMin = 8;
    int initialPlanetsMax = 18;

    //float starPosMinX = -12.0f;
    //float starPosMaxX = 5.0f;

    float starPosMinY = 2f;
    float starPosMaxY = 7f;

    float starPosMinX = -10.0f;
    float starPosMaxX = 20.0f;

    float offsetX = 30.0f;

    float waitBeforeAppearPlanetMin = 0.4f;
    float waitBeforeAppearPlanetMax = 1.8f;

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
}
