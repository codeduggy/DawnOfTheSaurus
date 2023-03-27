using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movespeed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] Vector2 death = new Vector2 (10f, 10f);
    [SerializeField] GameObject projectile;
    [SerializeField] Transform spit;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator; 
    CapsuleCollider2D myCapsuleCollider;
    BoxCollider2D myBoxCollider;
    
    bool isAlive = true;
    
   
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
    }

    
    void Update()
    {
        if(!isAlive)
        {
            return;
        }
        Run();
        FlipSprite();
        Die();
        
    }
    
    void OnFire(InputValue value)
    {
        if(!isAlive)
        {
            return;
        }
        Instantiate(projectile, spit.position, transform.rotation);

    }

    void OnMove(InputValue value)
    {
        if (!isAlive)
        {
            return;
        }
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void OnJump(InputValue value)
    {
        if(!isAlive)
        {
            return;
        }
        if(!myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }

        if (value.isPressed)
        {
            myRigidbody.velocity += new Vector2 (0f, jumpForce);

            
        }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2 (moveInput.x * movespeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isrunning", playerHasHorizontalSpeed);
    }
    
    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            

            transform.localScale = new Vector2 (Mathf.Sign(myRigidbody.velocity.x), 1f);
        
        }

    }

    void Die()
    {
        if (myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazard")))
        {
            isAlive = false;
            myAnimator.SetTrigger("Death");
            myRigidbody.velocity = death;
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
    }
}
