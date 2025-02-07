using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    float gravityScale = 1.5f;

    bool isGrounded = false;

    [SerializeField]
    Transform groundedRayOrigin;

    [SerializeField]

    LayerMask groundedRayLayerMask;

    float groundedRayDistance = 0.5f;

    Vector3 groundedRayDirection = Vector3.down;

    void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        myRb.gravityScale = gravityScale;
        //myRb.gravityScale = 0; // for test
    }

    void Update()
    {
        Move();
        CheckGrounded();
    }

    void Move()
    {
        //myRb.velocity = new Vector2(movementSpeed * Time.deltaTime, myRb.velocity.y);
        //Debug.Log("mySpeed= " + movementSpeed * Time.deltaTime);

        myRb.velocity = new Vector2(movementSpeed, myRb.velocity.y);
        //Debug.Log("mySpeed= " + movementSpeed);
    }

    void CheckGrounded()
    {
        Debug.DrawRay(groundedRayOrigin.position, groundedRayDirection * groundedRayDistance, Color.blue);
        RaycastHit2D hit = Physics2D.Raycast
        (
            transform.position,
            groundedRayDirection,
            groundedRayDistance,
            groundedRayLayerMask
        );
        if (hit)
        {
            Debug.DrawRay(groundedRayOrigin.position, groundedRayDirection * groundedRayDistance, Color.red);
            Debug.Log("Did Hit");
            isGrounded = true;
        }
        else
        {
            Debug.DrawRay(groundedRayOrigin.position, groundedRayDirection * groundedRayDistance, Color.green);
            Debug.Log("Did not Hit");
            isGrounded = false;
        }
    }

    public void Jump()
    {
        if (!isGrounded)
        {
            return;
        }
        myRb.AddForce(Vector2.up * jumpForce);
    }

    internal void TakeDamage()
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
