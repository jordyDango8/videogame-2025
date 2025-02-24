using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformColliderTest : MonoBehaviour
{
    SpriteRenderer mySprite;
    EdgeCollider2D myCollider;

    [SerializeField]
    float offsetY = -0.1f;

    [ContextMenu("Adjust Collider")]
    public void AdjustCollder()
    {
        Debug.Log("adjust collider");

        myCollider = GetComponent<EdgeCollider2D>();
        if (myCollider != null)
        {
            Vector2 offset = myCollider.offset;
            offset.y = offsetY;
            myCollider.offset = offset;
        }
        else
        {
            Debug.LogWarning("EdgeCollider2D component not found!");
        }

        mySprite = GetComponent<SpriteRenderer>();
        if (mySprite != null)
        {
            //get width of sprite
            float width = mySprite.bounds.size.x;
            Vector2[] newPoints = new Vector2[2];
            newPoints[0] = new Vector2(0, 0);
            newPoints[1] = new Vector2(width, 0);
            myCollider.points = newPoints;
        }
        else
        {
            Debug.LogWarning("SpriteRenderer2D component not found!");
        }
    }
}
