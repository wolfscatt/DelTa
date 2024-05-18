using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class AnimalController : MonoBehaviour
{
    public Transform player; // Takip edilecek karakterin Transform'u
    public float followDistance = 1f; // Karakterin arkasında kalınacak mesafe
    public float moveSpeed = 5f; // Evcil hayvanın hareket hızı

    void FixedUpdate()
    {
       // Karakterin pozisyonu ile evcil hayvanın pozisyonu arasındaki mesafeyi hesapla
        float distance = Vector2.Distance(player.position, transform.position);

        // Eğer karaktere belirli bir mesafeden daha uzaktaysa evcil hayvanı hareket ettir
        if (distance > followDistance)
        {
            // Karakterin pozisyonuna doğru yön vektörünü hesapla
            Vector2 direction = (player.position - transform.position).normalized;

            // Yeni pozisyonu hesapla
            Vector2 newPosition = (Vector2)transform.position + direction * moveSpeed * Time.deltaTime;

            // Evcil hayvanı yeni pozisyona taşı
            transform.position = newPosition;
        }
    }
    
 
}

