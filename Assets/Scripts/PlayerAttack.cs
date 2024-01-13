using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 2;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;
    void Start()
    {
       anim = GetComponent<Animator>(); 
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && cooldownTimer > attackCooldown)
        {
            Attack();
        }

        cooldownTimer += Time.deltaTime;
    }
    private void Attack()
    {
        print("test");
        anim.SetTrigger("shooting");
        cooldownTimer = 0;
    }
}
