using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class StartANewGame : MonoBehaviour
{
    public void OnNewGameClicked() 
    {
        DataPersistenceManager.instance.NewGame();
    }
}
