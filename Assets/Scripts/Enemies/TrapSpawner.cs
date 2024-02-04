using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    [SerializeField] private GameObject fallingTrap;

    private void Start()
    {
       gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        GetComponent<Animator>().Play("RuneSpawning", - 1, 0f);   
    }

    private void SpawnTrap()
    {
        Instantiate(fallingTrap, transform.position, transform.rotation);
    }
    private void DisableObject()
    {
        gameObject.SetActive(false);
    }
    
}
