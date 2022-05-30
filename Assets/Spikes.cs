using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private void Awake()
    {
       spriteRenderer = GetComponent<SpriteRenderer>();
       animator = GetComponent<Animator>();
    }

    private void Start()
    {
        spriteRenderer.enabled = false;
        animator.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            spriteRenderer.enabled = true;
            animator.enabled = true;
        }
    }
}
