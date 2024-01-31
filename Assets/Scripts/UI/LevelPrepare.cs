using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelPrepare : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI descriptionTextField;
    [SerializeField] private Button levelSelectedButton;

    [SerializeField] string description;
    [SerializeField] private Image _img;
    [SerializeField] private Sprite _default, _active, _finished;// _locked;
    [SerializeField] private int level;
    //private int level = 2;
    private int state = 0;
    public void SetState(int newValue)
    {
        state = newValue;
        SpriteUpdate();
    }
    public void SetupLevelDescriptionAndDestination()
    {
        if (state != 0)
        {
            descriptionTextField.text = description;
            OpenLevel buttonScript = levelSelectedButton.gameObject.GetComponent<OpenLevel>();
            buttonScript.Level = level;
        }
        else
        {
            descriptionTextField.text = "Finish level " + ( level - 1) + " first.";
        }

    }
    //setting what level should this button send
    public int getLevel()
    { return level; }
    private void SpriteUpdate()
    {
        
        switch (state)
        {   
            case 0:
                _img.sprite = _default;
                break;
            case 1:
                _img.sprite = _active;
                break;
            case 2:
                _img.sprite = _finished;
                break;
            /*case 3:
                _img.sprite = _locked;
                break;*/
            default:
                break;
        }
    }
    //private void SendState
    
}
