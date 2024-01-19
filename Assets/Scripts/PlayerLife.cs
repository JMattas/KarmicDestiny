using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int maxPlayerHealth = 3;
    public int playerCurrentLife { get; private set; }
     
    private Rigidbody2D rb;
    private Animator anim;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerCurrentLife = maxPlayerHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Hurt(1);
        }
    }
    private void Hurt(int damage)
    {

        playerCurrentLife -= damage;
       // HealthSystem.UpdateHealth();
        //pøidat metodu na update DMG
        //HealthSystem.
        if (playerCurrentLife <= 0) Die();
    }
    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }


    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
