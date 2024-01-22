using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] GameObject backSideOfHealthPrefab;
    [SerializeField] PlayerLife playerLife;
    private int maxHealth;
    private int lastHealthUpdated;
    List<Transform> currentHealthPoints = new List<Transform>();

    void Start()
    {
        maxHealth = playerLife.playerCurrentLife;
        lastHealthUpdated = maxHealth;
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject instantiatedPrefab = Instantiate(backSideOfHealthPrefab,transform);
            Transform nestedObject = instantiatedPrefab.transform.Find("Healthpoint");
            if (nestedObject != null)
            {
                currentHealthPoints.Add(nestedObject);
            }
            else
            {
                Debug.LogWarning("NestedObject not found in prefab #" + i);
            }
        }
        UpdateHealth();
    }
    private void Update()
    {
        if (lastHealthUpdated != playerLife.playerCurrentLife)
        {
            lastHealthUpdated = playerLife.playerCurrentLife;
            UpdateHealth();
        }
        
    }
    public void UpdateHealth()
    {
        foreach (Transform nestedObject in currentHealthPoints)
        {
            if (currentHealthPoints.IndexOf(nestedObject) < playerLife.playerCurrentLife)
            {
                nestedObject.gameObject.SetActive(true);
            }
            else
            {
                nestedObject.gameObject.SetActive(false);
            }
        }   
    }
}
