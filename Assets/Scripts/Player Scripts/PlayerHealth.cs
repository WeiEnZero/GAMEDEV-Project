using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour 
{
    // Initialising the player health
    public int player_health = 50;
    private int health;
    private BoxCollider2D RB { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created.
    void Start()
    {
        health = player_health;
        RB = GetComponent<BoxCollider2D>();

    }

    // Function to destroy the GameObject (Player) when health reaches 0.
    // Uses damage as a argument integer.
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"Player has taken {damage} damage");
        if (health <= 0 )
        {
            Destroy(gameObject);
        }
    }
}
