using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour, IDataPersistence
{
    private bool collected = false;
    private Animator anim;
    [SerializeField] private GameObject updateCoinCounterInTextField;
    [SerializeField] private string id;
    
    [ContextMenu("Generate guid for id")]

    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void LoadData(GameData data)
    {
        data.coinList.TryGetValue(id, out collected);
        if (collected)
        {
            Destroy(gameObject);
        }

    }
    public void SaveData(GameData data)
    {
        if (data.coinList.ContainsKey(id))
        {
            data.coinList.Remove(id);
        }
        data.coinList.Add(id, collected);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            updateCoinCounterInTextField.gameObject.GetComponent<CoinsStatus>().collectedCoin();
            collected = true;
            AudioManager.instance.PlaySFX("CoinCollected");
            anim.SetTrigger("collected");
        }

    }
    private void DestroyAfterAnimation()
    {
        Destroy(gameObject);
        
    }

}
