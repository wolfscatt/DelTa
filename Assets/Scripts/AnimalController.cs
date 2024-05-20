using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    public GameObject character;
    public float followDistance = 2.0f;
    public float respawnDistance = 10f;
    public float speed = 5.0f;
    public float jumpForce = 7;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private bool jump;
    private bool grounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        Collider2D characterCollider = character.GetComponent<Collider2D>();
        if (characterCollider != null)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), characterCollider);
        }
    }

    void FixedUpdate()
    {
        FollowCharacter();

        if (jump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
            grounded = false;
            animator.SetTrigger("jump");
        }
    }

    void Update()
    {
        float distanceToCharacter = Vector2.Distance(transform.position, character.transform.position);
        if (character != null)
        {
            CharacterController characterController = character.GetComponent<CharacterController>();

            if (grounded && characterController.verticalInput > 0 && characterController.grounded)
            {
                jump = true;
            }
        }

        if(distanceToCharacter > respawnDistance)
        {
            transform.position = new Vector3(character.transform.position.x - 1, character.transform.position.y, transform.position.z);
        }

        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        animator.SetBool("grounded", grounded);
        animator.SetBool("jump", jump);
    }

    private void FollowCharacter()
    {
        if (character != null)
        {
            float distanceToCharacter = Vector2.Distance(transform.position, character.transform.position);

            if (distanceToCharacter > followDistance)
            {
                Vector3 direction = (character.transform.position - transform.position).normalized;
                rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);

                spriteRenderer.flipX = direction.x < 0;
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
