using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOffsetTest : MonoBehaviour
{
    public float offsetX = 0.1f;
    public float offsetY = 0.1f;

    private Material material;

    void Start()
    {
        // Get the material of the sprite renderer
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        // Calculate the new offset
        Vector2 offset = new Vector2(offsetX * Time.time, offsetY * Time.time);

        // Apply the offset to the material
        material.mainTextureOffset = offset;
    }
}
