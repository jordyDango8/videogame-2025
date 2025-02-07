using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBehaviour : MonoBehaviour
{
    SpriteRenderer mySpriteRenderer;

    [SerializeField]
    ParticleSystem pickUpPS;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("collided with: " + other.name);
        if (other.CompareTag(EnumManager.Tags.Player.ToString()))
        {
            BeCollected();
        }
    }

    void BeCollected()
    {
        //Debug.Log("be collected");
        mySpriteRenderer.enabled = false;
        pickUpPS.Play();
        FindObjectOfType<PlayerData>().SetStars(FindObjectOfType<PlayerData>().GetStars() + 1);
        FindObjectOfType<ProgressSliderHelper>().UpdateSlider();
    }

    void OnEnable()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        var pickUpMain = pickUpPS.main;
        pickUpMain.loop = false;
    }
}
