using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private float lenght, startPosX, startPosY;
    [SerializeField] private GameObject cam;
    [SerializeField] private float parallaxEffect;
    void Start()
    {
        startPosX = transform.position.x;
        startPosY = transform.position.y;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    //lateupdate so camera is already updated
    void LateUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float xDist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startPosX + xDist, startPosY, transform.position.z);

        if (temp> startPosX + lenght)
        {
            startPosX += lenght;
        }else if (temp<startPosX -lenght)
        {
            startPosX -= lenght;
        }
    }
}
