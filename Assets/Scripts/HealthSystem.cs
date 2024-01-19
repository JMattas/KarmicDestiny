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
    List<Transform> currentHealthPoints = new List<Transform>();
    Image healthImage;
    void Start()
    {
        maxHealth = playerLife.playerCurrentLife;
        Debug.Log(maxHealth);
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
        if (maxHealth != playerLife.playerCurrentLife)
        {
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
