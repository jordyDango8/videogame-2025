using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOffsetTest : MonoBehaviour
{
    public Vector2 offset;

    void Update()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            Debug.Log(" Adjust the offset");
            var srr = spriteRenderer.sprite.rect;
            srr.center += offset;
        }
    }
}
