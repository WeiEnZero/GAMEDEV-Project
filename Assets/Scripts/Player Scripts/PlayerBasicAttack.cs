using UnityEngine;

public class PlayerBasicAttack : MonoBehaviour
{
    private GameObject attackRange = default;

    private bool attacking = false;

    private float timeToAttack = 0.25f;
    private float timer = 0f;


    void Start()
    {
        attackRange = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        if(attacking)
        {
            if(timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackRange.SetActive(attacking);
            }
        }
    }

    private void Attack()
    {
        attacking = true;
        attackRange.SetActive(attacking);
    }
}
