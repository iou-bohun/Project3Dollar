using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    [SerializeField] private GameObject _inventory;
    
    public void InventoryBtn()
    {
        Debug.Log("touch");
        if (_inventory.activeSelf)
        {
            _inventory.SetActive(false);
        }
        else
        {
            _inventory.SetActive(true);
        }
    }
}
