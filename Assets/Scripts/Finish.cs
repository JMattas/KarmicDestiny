using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private bool levelCompleted = false;
    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            levelCompleted = true;
            //sounds?
            Invoke("CompleteLevel", 2f);
            
        }
    }
    private void CompleteLevel()
    {
        //vracíme do main menu, upravit
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
