using UnityEngine;

public class BasicEnemyAttack : MonoBehaviour
{
    public int damage = 10;
    public PlayerHealth health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            health.TakeDamage(damage);
        }
    }
}
