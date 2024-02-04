using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour, IDataPersistence
{
    private bool levelCompleted = false;
    private Rigidbody2D rb;
    private float speed = 7f;
    private float simulationDuration = 10f;
    [SerializeField] CameraController followingPlayer;
    [SerializeField] GameObject confirmationWindow;
    private int tempLevelfromData;
    
    // Start is called before the first frame update
    void Update()
    {
        if (simulationDuration < 2f)
        {
            RunningSimulation();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            TurnOffCameraFollowing();
            collision.gameObject.GetComponent<PlayerMovement>().EnableMomevementControls = false;
            rb = collision.gameObject.GetComponent<Rigidbody2D>();
            simulationDuration = 0f;
            levelCompleted = true;
            //sounds?
            Invoke("CompleteLevel", 2f);
            
        }
    }
    private void TurnOffCameraFollowing()
    {
        followingPlayer.FollowingPlayer = false;

    }
    private void RunningSimulation()
    {
        simulationDuration += Time.deltaTime;
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
    private void CompleteLevel()
    {
        confirmationWindow.SetActive(true);

        if (tempLevelfromData < SceneManager.GetActiveScene().buildIndex)
        {
            tempLevelfromData=SceneManager.GetActiveScene().buildIndex;
        }
        DataPersistenceManager.instance.SaveGame();

    }

    public void LoadData(GameData data)
    {
        this.tempLevelfromData = data.unlockedLevel;
    }

    public void SaveData(GameData data)
    {
        data.unlockedLevel = this.tempLevelfromData;
    }
}
