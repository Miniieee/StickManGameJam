using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxReaction : MonoBehaviour
{
    private Rigidbody2D myRigidBody2D;


    private void Awake()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            myRigidBody2D.gravityScale = 2f;
        }
    }


}
