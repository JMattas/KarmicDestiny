using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class ButtonVisibilityController : MonoBehaviour
{
    [SerializeField] private List<Button> buttonsRightSide = new List<Button>();
    [SerializeField] private List<Button> buttonsLeftSide = new List<Button>();
    public Animator anim;
    public float pageCounter = 1;
    // Start is called before the first frame update
    void Start()
    {
        //ButtonActivation();
        anim = GetComponent<Animator>();
        SetPageCounterAnimator();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetPageCounter(float pageNumber)
    {
        
        pageCounter = pageNumber;
        SetPageCounterAnimator();
        
    }

    //pøidat ButtonActivation(); do každého statu
    private void SetPageCounterAnimator()
    {
        //ButtonDeactivation();
        anim.SetInteger("page", (int)pageCounter);
        ButtonActivation();
    }
    private void ButtonDeactivation()
    {
        foreach (Button button in buttonsLeftSide)
        {
            button.enabled = false;
        }
        foreach (Button button in buttonsRightSide)
        {
            button.enabled = false;
        }
    }
    private void ButtonActivation()
    {
        if (buttonsRightSide.Count == buttonsLeftSide.Count && pageCounter>=0)
        {
            for (int i = 0; i < buttonsRightSide.Count; i++)
            {
                if (i>pageCounter)
                {
                    buttonsRightSide[i].enabled = true;
                    buttonsLeftSide[i].enabled = false;
                }
                else
                {
                    buttonsRightSide[i].enabled = false;
                    buttonsLeftSide[i].enabled = true;
                }
                
            }
        }
        else
        {
            Debug.Log("Buttons on right "+ buttonsRightSide.Count+ ", Buttons on left "+ buttonsLeftSide.Count +",Page counter "+pageCounter);
        }

    }
}
