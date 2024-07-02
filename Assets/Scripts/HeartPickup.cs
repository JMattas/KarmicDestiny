using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    private Animator anim;
    private bool collectable = true;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collectable)
        {
            collectable = false;
            collision.gameObject.GetComponent<PlayerLife>().Heal(1);
            AudioManager.instance.PlaySFX("HeartCollected");
            anim.SetTrigger("collected");
        }
    }
    private void DestroyAfterAnimation()
    {
        Destroy(gameObject);
        
    }
}
