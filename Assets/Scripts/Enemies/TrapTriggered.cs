using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTriggered : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            anim.SetTrigger("triggered");
        }
    }
    private void RemoveItself()
    {
        Destroy(gameObject);
    }
}
