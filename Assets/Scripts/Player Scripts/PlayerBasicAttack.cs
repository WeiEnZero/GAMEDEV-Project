using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class PlayerBasicAttack : MonoBehaviour
{
    private GameObject attackRange = default;
    private bool attacking = false;
    private Animator animator;
    private float timeToAttack = 1f;
    private float timer = 0f;


    void Start()
    {
        attackRange = transform.GetChild(0).gameObject;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetMouseButtonDown(0)) // When Right Click input is detected, the Attack function will be activated.
        {
            Attack();
        }

        if (attacking)
        {
            timer += Time.deltaTime;  // When attacking mode is ture, the cooldown timer will be activated and start cooldown increment.
            if (timer >= timeToAttack) // When the timer is more than or equal to the attacking time, the cooldown timer resets to 0, attacking mode will be false and the attack range will be deactivated to be false.
            {
                timer = 0;
                attacking = false;
                attackRange.SetActive(attacking);
            }
        }
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0)) // On a fixed frames, the right click input will also set the attacking animation to be true.
        { 
            animator.SetBool("Attacking", true);
        }
    }

    private void Attack()  // Attack function is used to set attacking mode to be true when input is received and the attack range will be activated to deal damage to the enemy object.
    {
        attacking = true;
        attackRange.SetActive(attacking);
    }


    public void EndAttack() // The EndAttack function makes Attacking animation to stop once attack animation is finished.
    {
        animator.SetBool("Attacking", false);
    }
}

