using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelMenu : MonoBehaviour , IDataPersistence
{
    private int unlockedLevel=0;
    [SerializeField] Button[] buttons;
    //states 0 - 3 _default, _active, _finished, _locked;
    private void UpdateStateOfEachButton()
    {

        foreach (Button button in buttons)
        {
            int state = 0;
            
            LevelPrepare buttonScript = button.gameObject.GetComponent<LevelPrepare>();
            
            if (unlockedLevel > buttonScript.getLevel())
            {
                state = 2;
            }
            else if(unlockedLevel == buttonScript.getLevel())
            {
                state = 1;
            }
            else
            {
                state = 0;
            }
            buttonScript.SetState(state);
        }
    }

    public void LoadData(GameData data)
    {
        this.unlockedLevel = data.unlockedLevel;
        UpdateStateOfEachButton();

    }
    public void SaveData(GameData data)
    {
        data.unlockedLevel = this.unlockedLevel;

    }
    
}
