using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Remember to set velocity and other components in the editor!
    // and Add groundlayer
    [SerializeField] private float velocity;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer; 
    [SerializeField] float jumpForce;
    [SerializeField] SpriteRenderer spriteRender;

    private float horizontal;
    private Rigidbody2D rb2d;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Jump();
        FlipSprite();
    }

    void FixedUpdate(){
        MoveHorizontally();
    }

    void MoveHorizontally(){
        rb2d.velocity = new Vector2(horizontal * velocity, rb2d.velocity.y);
    }

    void Jump(){
        bool canJump = isGrounded();
        if(canJump && Input.GetButtonDown("Jump")){
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }
    }

    bool isGrounded(){
        return Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);
    }

    void FlipSprite(){
        if(horizontal > 0){
            spriteRender.flipX = false;
        } else if (horizontal < 0){
            spriteRender.flipX = true;
        }
    }
}
