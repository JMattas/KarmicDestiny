using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemCollector : MonoBehaviour
{
    private int hearts = 0;
    [SerializeField] private Text heartsText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Heart"))
        {
            Destroy(collision.gameObject);
            hearts++;
            heartsText.text = "Number of Hearts: " + hearts;
        }

    }

}
