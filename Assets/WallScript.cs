using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    private Rigidbody2D myrigidbody2D;
    [SerializeField] float speed = 20f;

    private void Awake()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        myrigidbody2D.gravityScale = 0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            myrigidbody2D.gravityScale = speed;
        }
        
    }
}
