using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyMinionFox : PlayerBehaviour
{
    float damage = 34.0f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(EnumManager.Tags.EnemyMinion.ToString()))
        {
            Die();
        }

        if (other.CompareTag(EnumManager.Tags.Boss.ToString()))
        {
            other.GetComponent<BossBehaviour>().TakeDamage(damage);
        }
        if (other.CompareTag(EnumManager.Tags.DeadZone.ToString())) // inheritance
        {
            Disappear();
        }
    }

    void Die()
    {
        audioManager.Play(EnumManager.Audio.unstitch);
        Destroy(gameObject);
    }

    void Disappear()
    {
        Destroy(gameObject);
    }

}
