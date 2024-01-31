using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenLevel : MonoBehaviour
{
    private int level = 0;
    [SerializeField] private TextMeshProUGUI descriptionTextField;

    public int Level
    {
        get { return level; }
        set { level = value; }
    }
    public void OpenSelectedLevel()
    { 
        if (SceneManager.sceneCountInBuildSettings > level+1)
        {        
            if (level > 0)
            {
                DataPersistenceManager.instance.SaveGame();
                SceneManager.LoadScene(level+1);
            }
            else
            {
                descriptionTextField.text = "Select level first!";
            }
        }
        else
        {
            Debug.LogError("Picked Level exceeded number of scenes in build, which is " + SceneManager.sceneCountInBuildSettings + ".");
        }
    }
}
