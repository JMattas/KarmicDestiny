using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingUntilNot : MonoBehaviour
{
    [SerializeField] private bool turnOffHitbox;
    [SerializeField] private LayerMask groundLayer;
    private BoxCollider2D coll;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();

    }
    void Update()
    {
        if (IsGrounded() && (rb.bodyType != RigidbodyType2D.Static))
        {
            if (coll != null && turnOffHitbox)
            {
                
                rb.bodyType = RigidbodyType2D.Static;
                coll.enabled = false;
            }
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, groundLayer);
    }

}
