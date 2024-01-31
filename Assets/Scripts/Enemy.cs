using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour, IDataPersistence
{
    [SerializeField] GameObject skull;
    [SerializeField] int health = 100;
    [SerializeField] private string id;
    [ContextMenu("Generate guid for id")]
    
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }
    private Animator anim;
    private bool killed = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        
    }
    public void LoadData(GameData data)
    {
        data.deathList.TryGetValue(id, out killed);
        if(killed)
        {
            //gameObject.SetActive(false);
            Die();
        }
    }
    public void SaveData(GameData data)
    {
        if(data.deathList.ContainsKey(id))
        {
            data.deathList.Remove(id);
        }
        data.deathList.Add(id, killed);
    }
 

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            anim.SetTrigger("dying");
            //Die();
        }
    }

    void Die()
    {
        killed = true;
        Destroy(gameObject);
        Instantiate(skull, transform.position, transform.rotation);
    }
}
