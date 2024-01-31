using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsStatus : MonoBehaviour, IDataPersistence
{
    private int coins = 0;
    private int coinsUsed = 0;
    [SerializeField] private TextMeshProUGUI descriptionTextField;
    public void LoadData(GameData data)
    {
        coins = data.coins;
        coinsUsed = data.coinsUsed;
        updateCoinCounter();
    }

    public void SaveData(GameData data)
    {
        data.coins = coins;
        data.coinsUsed = coinsUsed;
    }
    public void collectedCoin()
    {
       coins++;
       updateCoinCounter() ;
    }
    private void updateCoinCounter()
    {
        descriptionTextField.text = "" + (coins - coinsUsed);
    }

}
