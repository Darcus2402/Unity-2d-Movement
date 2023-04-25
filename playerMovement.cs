using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private float horizontal;
    private Rigidbody2D rb2d;
    [SerializeField] private SpriteRenderer spriteRend;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] float velocity = 5f;
    [SerializeField] float jumpForce = 7f;

    // Start is called before the first frame update

    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
    }

    
    void Update(){
        horizontal = Input.GetAxisRaw("Horizontal");
        Jump();

        FlipSprite();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveHorizontally();

    }


    void MoveHorizontally(){
        rb2d.velocity = new Vector2(horizontal * velocity, rb2d.velocity.y);
    }

    void Jump(){
        bool canJump = isGrounded();

        if(canJump) Debug.Log("Can jump");  
        if(canJump && Input.GetButtonDown("Jump")){
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }
    }

    private bool isGrounded(){
        // crea un cerchio, che se tocca, ritorna true
        return Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);
    }

    void FlipSprite(){
        if(horizontal > 0){
            spriteRend.flipX = false;
        } else if (horizontal < 0) {
            spriteRend.flipX = true;
        }
    }
}
