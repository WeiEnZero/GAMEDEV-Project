using UnityEngine;

public class PlayerHealth : MonoBehaviour 
{
    private int player_health = 10;
    private int health;
    private BoxCollider2D RB { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = player_health;
        RB = GetComponent<BoxCollider2D>();
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player has taken damage");
        if (health <= 0 )
        {
            Destroy(gameObject);
        }
    }
}
