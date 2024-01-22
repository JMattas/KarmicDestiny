using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class EventPlayerCollision : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 7f;
    private float simulationDuration = 10f;
    private enum MovementState { idle, running, jumping, falling }
    public CameraController followingPlayer;
    public PlayerMovement PlayerMovement;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (simulationDuration < 2f) { 
            RunningSimulation();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            TurnOffCameraFollowing();
            PlayerMovement.DisableMomevementControls = false;
            simulationDuration = 0f;
        }

    }
    void TurnOffCameraFollowing()
    {
        followingPlayer.FollowingPlayer = false;
        
    }
    private void RunningSimulation()
    {
        simulationDuration += Time.deltaTime;
        //transform.Translate(Vector2.right * speed * Time.deltaTime);
        rb.velocity = new Vector2(1 * speed, rb.velocity.y);

    }
}
