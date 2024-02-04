using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameWindowController : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject player;
    private bool paused = false;

    void Update()
    {

        if (Input.GetButtonDown("Cancel"))
        {
            if (!paused && player.gameObject.GetComponent<PlayerMovement>().EnableMomevementControls)
            {
                OpenWindow(pauseMenu);
                
            }
            else if(paused)
            {
                CloseWindow(pauseMenu);
            }
        }
        
    }

    private void OpenWindow(GameObject chosenWindow)
    {
        paused = true;
        Time.timeScale = 0f;
        chosenWindow.SetActive(true);
        player.gameObject.GetComponent<PlayerMovement>().EnableMomevementControls = false;



    }
    public void CloseWindow(GameObject chosenWindow)
    {
        paused = false;
        Time.timeScale = 1.0f;
        chosenWindow.SetActive(false);
        player.gameObject.GetComponent<PlayerMovement>().EnableMomevementControls = true;
    }
}
