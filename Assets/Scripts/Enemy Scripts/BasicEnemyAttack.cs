using UnityEngine;

public class BasicEnemyAttack : MonoBehaviour
{
    // Set the attack damage for the Basic enemy and initialise the health linked to PlayerHealth.
    public int damage = 5;
    public PlayerHealth health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            health = player.GetComponent<PlayerHealth>();
        }
    }

    //The OnCOllisionEnter2D function is used to detect the GameObject with "Player" Tag
    //Deals the damage amount using the TakeDamage function from Player Health Script.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            health.TakeDamage(damage);
        }
    }
}
