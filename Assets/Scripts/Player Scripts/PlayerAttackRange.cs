using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttackRange : MonoBehaviour
{
    private int damage = 20;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        BasicEnemyHealth health = collider.GetComponent<BasicEnemyHealth>();  // When the Enemy object enters the Attack Range, the collider component will get the Health Script Componenet from the enemy objects.
        if (health != null)   // If the enemies health has a integer and not null, the TakePayerDamage from the Basic Attack Script will be activated to deal 20 damage to the enemy in the range.
        {
            health.TakePlayerDamage(damage);
        }
    }
}
