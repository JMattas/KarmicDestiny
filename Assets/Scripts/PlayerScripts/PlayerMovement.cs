using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;


    [SerializeField] private Vector2 boxSize;
    [SerializeField] private float castDistance;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 12f;
    private float dirX = 0f;
    private bool facingRight = true;
    private bool manualMovementAllowed = true;
    private enum MovementState { idle, running, jumping, falling }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!(rb.bodyType == RigidbodyType2D.Static || !manualMovementAllowed))
        {
                dirX = Input.GetAxisRaw("Horizontal");
                rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

                if (Input.GetButtonDown("Jump") && IsGrounded())
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                }
        }
        UpdateAnimationState();
    }
    public bool DisableMomevementControls
    {
        get { return manualMovementAllowed; }
        set { manualMovementAllowed = value; dirX = 1f; }
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
            if (facingRight != true)
            {
                Flip();
            }

        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            if (facingRight)
            {
                Flip();
            }
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

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
        
    }
    private bool IsGrounded()
    {
        return (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer));
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance,boxSize);
    }
}
