using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsController : MonoBehaviour
{
    // the stars must appear at begin
    // the stars must desappear when leave from left
    // the stars must appear constantly in the rigth side of the player
    [SerializeField]
    StarBehaviour[] stars;

    [SerializeField]
    Transform player;

    int beginStarsMin = 18;
    int beginStarsMax = 28;

    //float starPosMinX = -12.0f;
    //float starPosMaxX = 5.0f;

    float starPosMinY = 2f;
    float starPosMaxY = 7f;

    float starPosMinX = -10.0f;
    float starPosMaxX = 20f;

    void Start()
    {
        PrepareScenario();
        //StartCoroutine(AppearAstro());
    }

    void PrepareScenario()
    {
        int beginStars = Random.Range(beginStarsMin, beginStarsMax);
        for (int i = 0; i < beginStars; i++)
        {
            int starIndex = Random.Range(0, stars.Length);
            stars[starIndex].Appear();
            float newPosX = Random.Range(starPosMinX, starPosMaxX);
            float newPosY = Random.Range(starPosMinY, starPosMaxY);
            Vector3 newPos = new Vector3(player.position.x + newPosX, newPosY, 0);
            stars[starIndex].ChangePosition(newPos);
        }
    }

    IEnumerator AppearAstro()
    {
        stars[Random.Range(0, stars.Length)].Appear();
        yield return new WaitForSeconds(1);
        StartCoroutine(AppearAstro());
    }
}
