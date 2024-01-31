using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableButtonIfNoData : MonoBehaviour
{
    [SerializeField] private Button continueButton;
    void Start()
    {
        if (!DataPersistenceManager.instance.HasGameData())
        {
            continueButton.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
