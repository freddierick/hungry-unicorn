using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerPlatformerController : PhysicsObject
{
    
    public float maxSpeed = 7;
    public float sprintSpeed = 2;
    public float jumpTakeOffSpeed = 7;


    public PowerUpManager powerUpManager;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    Animation anim;




    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero; 

        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");



        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }

        else if (Input.GetButtonUp("Jump"))
        {
            
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }


        if (Input.GetButtonDown("Special1") && powerUpManager.DoubbleJumpAsk() != (Input.GetButtonDown("Jump")))
        {
            velocity.y = jumpTakeOffSpeed;
            powerUpManager.DoubbleJumpDone();
        }

        else if (Input.GetButtonUp("Special1"))
        {

            if (velocity.y > 0)
            {
                velocity.y = velocity.y + 10f;
            }
        }




        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        //animator.SetBool("grounded", grounded);
        //animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
        animator.SetInteger("State", 1);
        //checks to see if the player is sprinting
        if (Input.GetButton("Sprint")){ targetVelocity = move * maxSpeed * sprintSpeed; } else { targetVelocity = move * maxSpeed; }
        

    }
}