using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClearSelection : MonoBehaviour

{
    [SerializeField] private TextMeshProUGUI descriptionTextField;
    [SerializeField] private Button levelSelectedButton;
    // Start is called before the first frame update
    public void ClearDescriptionAndStartButton()
    {
        OpenLevel buttonScript = levelSelectedButton.gameObject.GetComponent<OpenLevel>();
        if (buttonScript != null)
        {
            buttonScript.Level = 0;
        }
        descriptionTextField.text = "";
    }
}
