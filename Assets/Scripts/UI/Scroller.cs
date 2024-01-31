using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] private RawImage _img;
    [SerializeField] private float _x, _y;
    [SerializeField] private float colorShiftingSpeed;
    private float maxColorValue = 0.7f;
    private float colorChangeEvent = 0;
    private float backwards = 1;
    private void Start()
    {
        _img.color = new Color(maxColorValue, maxColorValue, maxColorValue);
    }
    private void Update()
    {
        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, _img.uvRect.size);

        colorChangeEvent++;
        if (colorChangeEvent >= colorShiftingSpeed*Time.deltaTime*100) changeColor();

    }

    private void changeColor()
    {
        if ((_img.color.r >= maxColorValue) || (_img.color.r <= (1f - maxColorValue)))
        {
            backwards = backwards * -1;
        }
        _img.color = new Color(_img.color.r + backwards * 0.001f, _img.color.g + backwards * 0.001f, _img.color.b + backwards * 0.001f);
        colorChangeEvent = 0;
    }
}
