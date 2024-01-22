using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int maxPlayerHealth = 3;
    public int playerCurrentLife { get; private set; }


    [SerializeField] private float iFramesDurtaion;
    [SerializeField] private int numberOffFlashes;
    private SpriteRenderer spriteRend;
    private Rigidbody2D rb;
    private Animator anim;
    void Awake()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerCurrentLife = maxPlayerHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        switch (collision.gameObject.tag)
        {   
            case "Trap":
                Hurt(1);
                break;
            case "Enemy":
                Hurt(1);
                break;
            default:
                break;
        }
        /*
        if (collision.gameObject.CompareTag("Trap")|| collision.gameObject.CompareTag("Enemy"))
        {
            Hurt(1);
        }
        if (collision.gameObject.CompareTag("Heart"))
        {
            Heal(1);
            Destroy(collision.gameObject);
        }
        */
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Heart":
                Heal(1);
                Destroy(collision.gameObject);
                break;
            default:
                break;
        }
    }
    private void Heal(int lifeGained)
    {
        playerCurrentLife += lifeGained;
        if (playerCurrentLife > maxPlayerHealth)
        {
            playerCurrentLife = maxPlayerHealth;
        }
    }
    private void Hurt(int damage)
    {

        playerCurrentLife -= damage;
        if (playerCurrentLife <= 0)
        {
            Die();
            return;
        }
        anim.SetTrigger("hurt");
        StartCoroutine(Invulnerability());
    }
    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    //10 is Player, 11 are Enemies
    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(10,11, true);
        for (int i = 0; i < numberOffFlashes; i++)
        {
            spriteRend.color = new Color(1, 1, 1, 0.5f);
            yield return new WaitForSeconds(iFramesDurtaion / (numberOffFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDurtaion / (numberOffFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
