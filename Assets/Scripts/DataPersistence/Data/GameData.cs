using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public int unlockedLevel;
    public int coins;
    public int coinsUsed;
    public int karma;
    public int playerDamage;
    public int currentMaxplayerHealth;
    public int maxPlayerHealth;
    public SerializableDictionary<string, bool> deathList;
    public SerializableDictionary<string, bool> coinList;


    public GameData()
    {
        this.unlockedLevel = 1;
        this.coins = 0;
        this.coinsUsed = 0;
        this.karma = 0;
        this.playerDamage = 20;
        this.currentMaxplayerHealth = 3;
        this.maxPlayerHealth = 5;
        deathList = new SerializableDictionary<string, bool>();
        coinList = new SerializableDictionary<string, bool>();
    }
}
