using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private float lenght, startposX, startposY;
    [SerializeField] private GameObject cam;
    [SerializeField] private float parallaxEffect;
    void Start()
    {
        startposX = transform.position.x;

        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startposX + dist, startposY, transform.position.z);

        if (temp> startposX + lenght)
        {
            startposX += lenght;
        }else if (temp<startposX-lenght)
        {
            startposX -= lenght;
        }
    }
}
