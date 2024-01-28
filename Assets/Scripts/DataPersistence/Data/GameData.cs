using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public int gold;
    public int karma;
    public int playerDamage;
    public int playerHealth;
    public SerializableDictionary<string, bool> deathList;

    public GameData()
    {
        this.gold = 0;
        this.karma = 0;
        this.playerDamage = 20;
        this.playerHealth = 3;
        deathList = new SerializableDictionary<string, bool>();
    }
}
