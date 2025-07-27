using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttackRange : MonoBehaviour
{
    private int damage = 3;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        EnemyHealth health = collider.GetComponent<EnemyHealth>();
        if (health != null)
        {
            health.TakePlayerDamage(damage);
        }
    }
}
