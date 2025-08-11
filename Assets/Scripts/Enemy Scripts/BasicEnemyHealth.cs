using System.Collections;
using UnityEngine;

public class BasicEnemyHealth : MonoBehaviour
{
    // Initialising the player health
    public int Enemy_health = 30;
    private int health;
    private BoxCollider2D RB { get; set; }
    private IEnumerator coroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created.
    void Start()
    {
        health = Enemy_health;
        RB = GetComponent<BoxCollider2D>();

    }

    // Function to destroy the GameObject (Player) when health reaches 0.
    // Uses damage as a argument integer.
    public void TakePlayerDamage(int damage)
    {
        health -= damage;
        Debug.Log("Enemy has taken damage");
        if (health <= 0)
        {
            StartCoroutine(RespawnAfterDelay(5f)); // Couroutine is used to ensure that the original prefab of the enemy is not destroyed.
        }
    }

    private IEnumerator RespawnAfterDelay(float delay)
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(delay);

        health = Enemy_health; // Reset health

        gameObject.SetActive(true);
    }
}
