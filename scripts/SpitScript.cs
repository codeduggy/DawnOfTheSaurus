using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitScript : MonoBehaviour
{
    [SerializeField] float spitSpeed = 5f;
    float xSpit;
    Rigidbody2D myRigidBody;
    PlayerMovement player;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        xSpit = player.transform.localScale.x * spitSpeed;
    }

    void Update()
    {
        myRigidBody.velocity = new Vector2 (xSpit, 0f);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Enemy")    
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy(gameObject);    
    }
}
