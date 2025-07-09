using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KnightControl : MonoBehaviour
{
    [SerializeField] private float speed = 4.0f;
    float speedX, speedY;
    private Rigidbody2D rigidBody;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * speed;
        speedY = Input.GetAxisRaw("Vertical") * speed;
        rigidBody.linearVelocity = new Vector2(speedX, speedY);

        if (speedX > 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        } else if (speedX < 0) {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void FixedUpdate()
    {
        if (rigidBody.linearVelocity.magnitude > 0)
        {
            WalkAnimation();
        }
        else
        {
            IdleAnimation();
        }
    }

    public void WalkAnimation()
    {
        animator.Play("Walk");
    }

    public void IdleAnimation()
    {
        animator.Play("Idle");
    }
}