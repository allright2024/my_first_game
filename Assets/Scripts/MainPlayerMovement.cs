using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    [SerializeField] private LayerMask jumpableGround;

    private enum MovementState {idle, running, jumping, falling}

    private static int characterIndex;
    private int index;
    // 0 : virtual boy, 1 : pink man, 2 : Ninja frog, 3 : Mask Dude
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        index = StartMenu.selectedSkin;
        // Debug.Log(StartMenu.selectedSkin);
        if(index == 0)
        {
            anim.SetInteger("character", 0);
        }
        else if (index == 1)
        {
            anim.SetInteger("character", 1);
        }
        else if (index == 2)
        {
            anim.SetInteger("character", 2);
        }
        else if (index == 3)
        {
            anim.SetInteger("character", 3);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // Debug.Log(characterIndex);
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationUpdate();
    }

    private void UpdateAnimationUpdate()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    
}
