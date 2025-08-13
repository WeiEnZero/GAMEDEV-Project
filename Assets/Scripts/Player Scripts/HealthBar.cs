using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class HealthBarsS : MonoBehaviour
{
    private Image HealthBar;
    public float CurrentHealth;
    private int MaxHealth = 50;
    public PlayerHealth player_health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the Image Component of the UI which is the red health bar image and it will be linked to HealthBar Variable.
        HealthBar = GetComponent<Image>();
        // If the Player_health variable from the PlayerHealth script contains a null value, the player_health will
        // find the gameObject Tag that has "player" and will access the "player" gameObject's PlayerHealth Script attached to it.
        if (player_health == null)
        {
            player_health = GameObject.FindGameObjectWithTag("Player")?.GetComponent<PlayerHealth>();
        }
    }
            

    // Update is called once per frame
    void Update()
    {
        // If the player_health is not null, the player_health.health from the PlayerHealth script will be set to the CurrentHealth Variable
        // and the HealthBar.fillAmount is equal to the current health over the Maxhealth variable so that the health can be calculated using
        // percentage.
        if (player_health != null)
        {
            int player_health1 = player_health.health;
            CurrentHealth = player_health1;
            HealthBar.fillAmount = CurrentHealth / MaxHealth;
            if (CurrentHealth == 0)
            {
                HealthBar.fillAmount = 0;
            }
        }
    }
}
