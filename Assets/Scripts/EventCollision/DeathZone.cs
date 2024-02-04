using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] CameraController followingPlayer;
    private PlayerLife playerLife;
    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            TurnOffCameraFollowing();
            playerLife = collision.gameObject.GetComponent<PlayerLife>();
            //playerLife.Hurt(playerLife.playerCurrentLife);
            Invoke("DelayedKilling", 2f);
        }
    }
    private void TurnOffCameraFollowing()
    {
        followingPlayer.FollowingPlayer = false;

    }
    private void DelayedKilling()
    {
        playerLife.Hurt(playerLife.playerCurrentLife);
    }
}
