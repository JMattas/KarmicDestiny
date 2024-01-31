using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActivityOfObject : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject m_gameObject;
    public void SetChosenObject(bool disable)
    {
        m_gameObject.SetActive(!disable);
    }
}
