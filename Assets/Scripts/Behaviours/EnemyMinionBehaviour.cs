using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMinionBehaviour : MonoBehaviour
{
    AudioManager audioManager;

    [SerializeField]
    BossBehaviour bossBehaviour;

    SpriteRenderer mySpriteRenderer;

    Collider2D myCollider;

    Transform orbitPoint;

    [SerializeField]
    float orbitSpeed;

    [SerializeField]
    float orbitRadius;

    [SerializeField]
    float speed;

    EnumManager.enemyMinionStates currentState = EnumManager.enemyMinionStates.dead;

    int myNumber;

    float damage = 34f;

    //bool isEnabled = false;

    void Update()
    {
        if (currentState == EnumManager.enemyMinionStates.orbiting)
        {
            Orbit();
        }
        else
        {
            //move to left
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(EnumManager.Tags.Tower.ToString()))
        {
            other.GetComponent<TowerBehaviour>().TakeDamage(damage);
        }
        if (other.CompareTag(EnumManager.Tags.AllyMinion.ToString()))
        {
            Die();
        }
        if (other.CompareTag(EnumManager.Tags.DeadZone.ToString()))
        {
            Disappear();
        }
    }

    internal void AdjustMyNumber(int _newNumber)
    {
        myNumber = _newNumber;
    }

    void Die()
    {
        audioManager.Play(EnumManager.Audio.unstitch);
        Disable();
    }

    void Disappear()
    {
        Disable();
    }

    void Disable()
    {
        currentState = EnumManager.enemyMinionStates.dead;
        //isEnabled = false;
        mySpriteRenderer.enabled = false;
        myCollider.enabled = false;
    }

    void Orbit()
    {
        //Debug.Log("orbiting");
        if (orbitPoint != null)
        {
            // Calcular la posición de la órbita
            float angle = (myNumber + Time.time) * orbitSpeed;
            float x = Mathf.Cos(angle) * orbitRadius;
            float y = Mathf.Sin(angle) * orbitRadius;

            // Actualizar la posición del objeto
            transform.position = new Vector3(orbitPoint.position.x + x, orbitPoint.position.y + y, transform.position.z);
        }
    }

    void ChangeState(EnumManager.enemyMinionStates _newState)
    {
        currentState = _newState;
    }

    internal void Attack()
    {
        //Debug.Log("attack");
        ChangeState(EnumManager.enemyMinionStates.attacking);
        transform.position = new Vector3(transform.position.x, orbitPoint.position.y, transform.position.z);
    }

    internal void Initialize(BossBehaviour _script, int _newNumber)
    {
        Enable();
        bossBehaviour = _script; // isn't necessary any time, fix
        orbitPoint = bossBehaviour.transform;
        ChangeState(EnumManager.enemyMinionStates.orbiting);
        myNumber = _newNumber;
    }

    void Enable()
    {
        SetIsEnabled(true);
        mySpriteRenderer.enabled = true;
        myCollider.enabled = true;
    }

    void OnEnable()
    {
        //Debug.Log($"{gameObject.name} onEnable");
        audioManager = AudioManager.audioManager;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<Collider2D>();
    }

    #region getters&setters
    /* internal bool GetIsEnabled()
    {
        return isEnabled;
    } */

    internal void SetIsEnabled(bool _newState)
    {
        //isEnabled = _newState;
    }

    internal EnumManager.enemyMinionStates GetCurrentState()
    {
        return currentState;
    }
    #endregion
}
