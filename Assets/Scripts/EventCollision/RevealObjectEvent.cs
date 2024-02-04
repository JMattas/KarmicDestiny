using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RevealObjectEvent : MonoBehaviour
{
    [SerializeField] private GameObject objectToShow;
    [SerializeField] private bool triggeredOnlyOnce = false;
    private bool triggered = false;
    private void Start()
    {
        objectToShow.SetActive(false);
        triggered = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggered)
        {
            if (collision.gameObject.name == "Player")
            {
                objectToShow.SetActive(true);
                triggered = triggeredOnlyOnce;
            }
        }

    }
}

