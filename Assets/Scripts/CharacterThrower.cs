using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterThrower : MonoBehaviour
{
    public GameObject projectilePrefab; // Fırlatılacak projectile prefab'i
    public Transform throwPoint; // Fırlatma noktası (karakterin el pozisyonu gibi)
    public float throwForce = 10f; // Fırlatma kuvveti
    public KeyCode throwKey = KeyCode.Space; // Fırlatma tuşu (örneğin, Boşluk tuşu)
    public float projectileLifetime = 3f;
    private Vector2 lastMoveDirection;
    private Animator animator;

    private void Start()
    {
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found!");
        }
    }

    void Update()
    {
        UpdateMoveDirection();

        // Fırlatma tuşuna basıldığında projectile fırlat
        if (Input.GetKeyDown(throwKey))
        {
            Debug.Log("Throw key pressed");
            ThrowProjectile();
        }
    }

    void UpdateMoveDirection()
    {
        // Yatay veya dikey eksende herhangi bir hareket varsa yönü güncelle
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            lastMoveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        }
    }

    void ThrowProjectile()
    {
        // Projectile prefab'ini instantiate et
        GameObject projectile = Instantiate(projectilePrefab, throwPoint.position, throwPoint.rotation);

        // Log to ensure throw is happening
        Debug.Log("Throwing projectile");
        animator.SetTrigger("throw");
        Debug.Log("Throw animation triggered");

        // Projectile'ye bir kuvvet uygula
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(lastMoveDirection * throwForce, ForceMode2D.Impulse);
        }
        else
        {
            Debug.LogError("Rigidbody2D component not found on projectile!");
        }

        Destroy(projectile, projectileLifetime);
    }
}
