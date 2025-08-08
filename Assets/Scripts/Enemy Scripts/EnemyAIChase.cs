using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAIChase : MonoBehaviour
{
    Transform Player;
    public float speed = 2f;
    Rigidbody2D rb;
    Vector2 moveDirection;
    public PlayerHealth playerHealth;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Player != null)
        {
            Player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

        // Update is called once per frame
        void Update()
        {
        if (Player != null && playerHealth != null && playerHealth.isDead != true)
        {
            Vector3 direction = (Player.position - transform.position).normalized;
            moveDirection = direction;


            if (moveDirection.x > 0)
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            else if (moveDirection.x < 0)
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        else
        {
            moveDirection = Vector2.zero; // stop moving if player is dead or missing
        }

        }

    private void FixedUpdate()
    {
        if (Player != null)
        {
            rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * speed;
        }
    }
}
