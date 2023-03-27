using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TyraScript : MonoBehaviour
{
    [SerializeField]float tyraSpeed = 1f;

    Rigidbody2D myRigidBody;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        myRigidBody.velocity = new Vector2 (tyraSpeed, 0f);
    }
    
    void OnTriggerExit2D(Collider2D other) 
    {
        tyraSpeed = -tyraSpeed;
        FlipTyraFacing();    
    }

    void FlipTyraFacing()
    {
       transform.localScale = new Vector2 (Mathf.Sign(myRigidBody.velocity.x), 1f);
    }
}
