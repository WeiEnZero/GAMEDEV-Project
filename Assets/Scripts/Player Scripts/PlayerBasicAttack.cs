using UnityEngine;

public class PlayerBasicAttack : MonoBehaviour
{
    private GameObject attackRange = default;
    private bool attacking = false;
    private Animator animator;
    private float timeToAttack = 0.1f;
    private float timer = 0f;


    void Start()
    {
        attackRange = transform.GetChild(0).gameObject;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        if (attacking)
        {
            timer += Time.deltaTime;
            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackRange.SetActive(attacking);
            }
        }
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AttackAnimation();
        }
    }

    private void Attack()
    {
        attacking = true;
        attackRange.SetActive(attacking);
    }

    public void AttackAnimation()
    {
        animator.Play("Attack");
    }
}

