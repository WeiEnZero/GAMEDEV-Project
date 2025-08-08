using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeroControl : MonoBehaviour
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
        //The input would get the raw axis of X and Y accoriding to vertical and horizontal direction
        speedX = Input.GetAxisRaw("Horizontal") * speed;
        speedY = Input.GetAxisRaw("Vertical") * speed;
        // The X and Y values are then used as arguments for Vector2 when the RigidBody.Velocity is used for character control on the X and Y axis
        rigidBody.linearVelocity = new Vector2(speedX, speedY);

        if (speedX > 0)
        {
            gameObject.transform.localScale = new Vector3(3.35655f, 3.35655f, 1);
        } 
        else if (speedX < 0) 
        {
            gameObject.transform.localScale = new Vector3(-3.35655f, 3.35655f, 1);
        }
    }

    private void FixedUpdate()
    {
        // If the movement magnitude of the hero is more than 0, the walk animation function is used else the Idle Animation is active.
        if (rigidBody.linearVelocity.magnitude > 0)
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            IdleAnimation();
        }
    }

    //Functions to get the specific animations from the Animator Component.
    public void WalkAnimation()
    {
        animator.Play("Walk");
    }

    public void IdleAnimation()
    {
        animator.SetBool("Walking", false);
    }
}