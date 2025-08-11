using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour 
{
    // Initialising the player health
    public int player_health = 50;
    public int health;
    private BoxCollider2D RB { get; set; }
    public GameManager gameManager;
    public bool isDead = false;

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
        if (health <= 0 && !isDead)
        {
            isDead = true;
            gameManager.gameOver();
            Destroy(gameObject);
        }
    }
}
