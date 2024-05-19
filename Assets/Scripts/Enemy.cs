using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 3; // Maximum health the enemy can have
    private int currentHealth;

    // Reference to the main character's timer
    public CharacterTimer mainCharacterTimer;

    void Start()
    {
        currentHealth = maxHealth; // Initialize the enemy's health
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce the enemy's health by the damage amount

        if (currentHealth <= 0)
        {
            Die(); // Call the Die method if health is 0 or less
        }
    }

    void Die()
    {
        // Add remaining time of the enemy to the main character's timer
        mainCharacterTimer.AddTime(mainCharacterTimer.initialTime / 2f); // For example, add half of the initial time

        // Handle enemy death (e.g., play animation, drop loot, etc.)
        Destroy(gameObject); // Destroy the enemy game object
    }
}
