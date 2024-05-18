using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 3f; // Düşmanın hareket hızı
    public float stoppingDistance = 3f; // Takip etmeye başlama mesafesi
    public float patrolSpeed = 2f; // Gezinme hızı
    public float patrolDistance = 2f; // Gezinme mesafesi
    public float patrolWaitTime = 1f; // Bir yerden diğerine giderken bekleme süresi

    private Vector2 startPosition; // Düşmanın başladığı pozisyon
    private Vector2 patrolPoint; // Gezinme hedef noktası
    private bool isFollowing = false; // Takip modunda mı?
    private bool isPatrolling = false; // Gezinme modunda mı?
    private float patrolTimer = 0f; // Gezinme bekleme süresi için timer

    void Start()
    {
        startPosition = transform.position;
        SetNewPatrolPoint();
    }

    void Update()
    {
        float distanceToTarget = Vector2.Distance(transform.position, target.position);

        // Hedefe belirli bir mesafeden daha uzaktaysa takip etmeyi durdur ve gezinmeye başla
        if (distanceToTarget > stoppingDistance)
        {
            isFollowing = false;

            Patrolling();
        }
        else
        {
            // Hedef belirli bir mesafeye yaklaştığında takibe başla
            isFollowing = true;
            isPatrolling = false;
        }

        // Takip modunda ise hedefe doğru hareket et
        if (isFollowing)
        {
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }
    void Patrolling()
    {
        // Eğer şu anda gezinmiyorsa yeni bir gezinme hedefi belirle
        if (!isPatrolling)
        {
            patrolTimer += Time.deltaTime;

            if (patrolTimer >= patrolWaitTime)
            {
                SetNewPatrolPoint();
                patrolTimer = 0f;
            }
        }
        else
        {
            // Gezinme noktasına doğru hareket et
            transform.position = Vector2.MoveTowards(transform.position, patrolPoint, patrolSpeed * Time.deltaTime);

            // Gezinme noktasına ulaştıysa beklemeye başla
            if (Vector2.Distance(transform.position, patrolPoint) < 0.1f)
            {
                isPatrolling = false;
            }
        }
    }

    // Yeni bir gezinme hedef noktası belirleme fonksiyonu
    void SetNewPatrolPoint()
    {
        patrolPoint = startPosition + new Vector2(Random.Range(-patrolDistance, patrolDistance), 0);
        isPatrolling = true;
    }
}
