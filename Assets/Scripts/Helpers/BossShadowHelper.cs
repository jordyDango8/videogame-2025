using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossShadowhHelper : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer damageShadowBar;

    [SerializeField]
    BossBehaviour bossBehaviour;

    float damageShadowBarMinHeight = 0.0f;
    float damageShadowBarMaxHeight = 16.5f;

    void Start()
    {
        // shadow size must start at max
        damageShadowBar.size = new Vector2(damageShadowBar.size.x, damageShadowBarMaxHeight);
    }

    void Update()
    {
        UpdateDamegeShadowBar();
    }

    void UpdateDamegeShadowBar()
    {
        //float curentDamage = (bossBehaviour.GetMaxHealth() - bossBehaviour.GetCurrentHealth());
        //float healthPercentage = curentDamage / bossBehaviour.GetMaxHealth(); // to make it from 0 to 1
        //float newHeight = Mathf.Lerp(damageShadowBarMinHeight, damageShadowBarMaxHeight, healthPercentage);

        float healthPercentage = bossBehaviour.GetCurrentHealth() / bossBehaviour.GetMaxHealth(); // to make it from 0 to 1
        float newHeight = Mathf.Lerp(damageShadowBarMinHeight, damageShadowBarMaxHeight, healthPercentage);
        damageShadowBar.size = new Vector2(damageShadowBar.size.x, newHeight);
        //print($"current health {bossBehaviour.GetCurrentHealth()}");
    }
}
