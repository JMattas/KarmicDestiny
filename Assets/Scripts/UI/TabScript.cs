using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class TabScript : MonoBehaviour
{
    [SerializeField] GameObject[] tabs;
    [SerializeField] GameObject levelPages;
    [SerializeField] TextMeshProUGUI buttonText;
    [SerializeField] TextMeshProUGUI textToPass;
    private void Start()
    {
        ButtonsToArray();
    }
    public void TurnOnSpecificTab(int chosenTab)
    {
        for (int i = 0; i < tabs.Length; i++)
        {
            tabs[i].SetActive(false);
        }
        tabs[chosenTab-1].SetActive(true);
        buttonText.text =textToPass.text;
    }
    private void ButtonsToArray()
    {
        int childCount = levelPages.transform.childCount;
        tabs = new GameObject[childCount];
        for (int i = 0; i < childCount; i++)
        {
            tabs[i] = levelPages.transform.GetChild(i).gameObject;
        }
    }
}
