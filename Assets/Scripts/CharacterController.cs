using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float jumpForce = 7;
    public float speed ;
    public float horizontalInput;
    public float verticalInput;

    private bool jump;
    private bool grounded = true;

    private Vector3 charPos;
    private Rigidbody2D rb;
    //private Animator animator;
    private SpriteRenderer spriteRenderer;
    [AllowNull]
    [SerializeField] private GameObject cam;

    private void Awake()
    {
        //animator = GetComponent<Animator>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        jumpForce = 8;
    }

    private void FixedUpdate()
    {
        
        rb.velocity = new Vector2(speed * horizontalInput, rb.velocity.y);
        if (jump)
        {
            //rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
            grounded = false;
            //animator.SetTrigger("jump");
        }
        charPos = transform.position;
    }


    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Sa�a ve sola hareketler
        if (grounded && horizontalInput != 0)
        {
            if(horizontalInput > 0) 
            { 
                spriteRenderer.flipX = false;
            }else if(horizontalInput < 0)
            {
                spriteRenderer.flipX = true;
            }
        }
        // Z�plama hareketi
        if(grounded && verticalInput > 0)
        {
            jump = true;
        }
        // animasyon g�ncellemeleri
        //animator.SetFloat("speed", Mathf.Abs(horizontalInput));
        //animator.SetBool("grounded", grounded);
        //animator.SetBool("jump", jump);

    }
    private void LateUpdate()
    {
        if (cam != null)
            cam.transform.position = new Vector3(charPos.x, charPos.y, -10);
        else 
            Debug.Log("Kamera Tanımlı Değil.");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
