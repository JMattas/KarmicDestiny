using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private bool followingPlayer = true;
    // Update is called once per frame
    void Update()
    {
        if (followingPlayer)
        {
            transform.position = new Vector3(player.position.x, player.position.y + 0.5f, transform.position.z);
        }
       
    }
    public bool FollowingPlayer
    {
        get { return followingPlayer; }
        set { followingPlayer = value; }
    }
}
