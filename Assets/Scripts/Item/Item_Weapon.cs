using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item_Weapon : Item_EquipmentItem
{
    public int durability;

    public void OnUseItem(int value)
    {
        durability -= value;
        Debug.Log(durability);
        if(durability <= 0)
        {
            Debug.Log("¹«±â ÆÄ±«");
            PlayerEquipmentUI.instance.Remove(10000);
        }
    }
    public Item_Weapon(ItemData_Weapon data) : base(data)
    {
        durability = data.MaxDurability;
    }
}
