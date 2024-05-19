using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 1; // Damage amount the projectile deals


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the projectile collides with an enemy
        Enemy enemy = collision.GetComponent<Enemy>();


        if (enemy != null)
        {
            enemy.TakeDamage(damage); // Deal damage to the enemy
            Destroy(gameObject); // Destroy the projectile on impact
        }
    }
}
