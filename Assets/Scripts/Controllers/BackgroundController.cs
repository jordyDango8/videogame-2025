using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField]
    StarBehaviour[] stars;

    void Start()
    {
        StartCoroutine(AppearAstro());
    }

    void Update()
    {

    }

    IEnumerator AppearAstro()
    {
        stars[Random.Range(0, stars.Length)].Appear();
        yield return new WaitForSeconds(1);
        StartCoroutine(AppearAstro());
    }
}
