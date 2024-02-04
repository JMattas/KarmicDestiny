using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage = 20;
    public Rigidbody2D rb;
    private float lifetime = 0;
    private Animator anim;

    void Start()
    {
        rb.velocity = transform.right * speed;
        anim = GetComponent<Animator>();
        
    }

    private void Update()
    {
        lifetime += Time.deltaTime;
        if (lifetime > 2)
        {
            EraseProjectile();
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
         Enemy enemy = hitInfo.GetComponent<Enemy>();
        
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        if (hitInfo.tag == "Event")
        {
            return;
        }
        //Debug.Log(hitInfo.name);
        EraseProjectile();
    }
    private void EraseProjectile()
    {
        GetComponent<CircleCollider2D>().enabled = false;
        rb.velocity = transform.right*0;
        anim.SetTrigger("explode"); 
    }

    private void Deactivate()
    {
        Destroy(gameObject);
    }
}
