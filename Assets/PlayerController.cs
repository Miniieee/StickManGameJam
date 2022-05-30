using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float jumpSpeed = 1f;
    [SerializeField] GameObject spawnedOne;


    private CharacterActionControl characterActionControl;
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;
    private BoxCollider2D myBoxCollider;
    private GameManager gameManager;

    
    private void Awake()
    {
        characterActionControl = new CharacterActionControl();
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        gameManager = FindObjectOfType<GameManager>();
    }

    
    void Update()
    {
        Move();
        FlipSprite();
        AnimatePlayer();
    }

    private void Move()
    {
        float moveInput = characterActionControl.Keyboard.Move.ReadValue<float>();

    

        if (moveInput >= 0)
        {
            Vector2 playerVelocity = new Vector2(moveInput * speed, myRigidbody.velocity.y);
            myRigidbody.velocity = playerVelocity;



        }
        if (moveInput < 0)
        {
            Vector2 playerVelocity = new Vector2(moveInput * speed, myRigidbody.velocity.y);
            myRigidbody.velocity = playerVelocity;

        }

    }


    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }

    private void AnimatePlayer()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("IsRunning", playerHasHorizontalSpeed);

    }

    void OnJump(InputValue value)
    {
        if (!myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }

        if (value.isPressed)
        {
            myRigidbody.velocity += new Vector2(0f, jumpSpeed);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Objects")
        {
            Destroy(gameObject);
            Instantiate(spawnedOne, transform.position, Quaternion.identity);
            Debug.Log("yepp1");
            gameManager.ResetScene();
        }
    }




    private void OnEnable()
    {
        characterActionControl.Enable();
    }

    private void OnDisable()
    {
        characterActionControl.Disable();
    }
}
