using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeHelper : MonoBehaviour
{        
    private Vector3 originalPosition;
    private bool isShaking = false;

    void ShakeCamera(float duration, float strength)
    {
        if (!isShaking)
        {
            StartCoroutine(Shake(duration, strength));
        }
    }

    private IEnumerator Shake(float duration, float strength)
    {
        originalPosition = transform.position;
        isShaking = true;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            transform.position += new Vector3(Random.Range(-strength, strength), Random.Range(-strength, strength), 0);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPosition;
        isShaking = false;
    }

    void OnEnable()
    {
        EventsManager.onCameraShake += ShakeCamera; 
    }

    void OnDisable()
    {
        EventsManager.onCameraShake -= ShakeCamera; 
    }

}
