using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float jumpForce = 7;
    public float speed;
    public float horizontalInput;
    public float verticalInput;

    private bool jump;
    public bool grounded = true;

    private Vector3 charPos;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private GameObject cam;
    [SerializeField] private Collider2D animalCollider; // Reference to the animal's collider

    private CharacterTimer characterTimer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        characterTimer = GetComponent<CharacterTimer>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        jumpForce = 8;

        if (animalCollider != null)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), animalCollider);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed * horizontalInput, rb.velocity.y);
        if (jump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
            grounded = false;
            animator.SetTrigger("jump");
        }
        charPos = transform.position;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (grounded && horizontalInput != 0)
        {
            spriteRenderer.flipX = horizontalInput < 0;
        }

        if (grounded && verticalInput > 0)
        {
            jump = true;
        }

        animator.SetFloat("speed", Mathf.Abs(horizontalInput));
        animator.SetBool("grounded", grounded);
        animator.SetBool("jump", jump);
    }

    //private void LateUpdate()
    //{
    //    if (cam != null)
    //        cam.transform.position = new Vector3(charPos.x, charPos.y, -10);
    //    else
    //        Debug.Log("Camera is not assigned.");
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
        if(collision.gameObject.CompareTag("Enemy"))
        {
            characterTimer.DecreaseTime(characterTimer.initialTime / 3); 
        }
    }
}
