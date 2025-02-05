using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    LivesController livesController;

    Rigidbody2D myRb;

    [SerializeField]
    float movementSpeed = 0;

    [SerializeField]
    float jumpForce = 0;

    int lives = 3;

    void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        //myRb.velocity = new Vector2(movementSpeed * Time.deltaTime, myRb.velocity.y);
        //Debug.Log("mySpeed= " + movementSpeed * Time.deltaTime);

        myRb.velocity = new Vector2(movementSpeed, myRb.velocity.y);
        //Debug.Log("mySpeed= " + movementSpeed);
    }

    public void Jump()
    {
        myRb.AddForce(Vector2.up * jumpForce);
    }

    void TakeDamage()
    {
        Debug.Log("take damage");

        livesController.TakeDamage();
        lives -= 1;
        if (lives <= 0)
        {
            lives = 0;
            Die();
        }
    }

    void Die()
    {
        //Debug.Log("die");
        EventsManager.CallOnGameOver(false);
    }
}
