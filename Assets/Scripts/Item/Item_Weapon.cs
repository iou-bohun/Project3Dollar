using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item_Weapon : Item_EquipmentItem
{
    public List<Item_Gem> _gems;

    public Item_Weapon(ItemData_Weapon data) : base(data) { 
        _gems = new List<Item_Gem>();
    }

    public void AddGem(Item item)
    {
        var data = this.Data as ItemData_Weapon;
        Debug.Log(data.Tier);
        if (_gems.Count < data.Tier)
        {
            var gem = item as Item_Gem;
            _gems.Add(gem);
        }
        else
        {
            Debug.Log("무기의 남은 잼 장착 공간이 없습니다.");
        }
    }

    public Item RemoveGem(int index)
    {
        if (_gems[index] != null)
        {
            Item gem = _gems[index];
            _gems.RemoveAt(index);
            return gem;
        }
        return null;
    }

    public bool IsGemAvailable()
    {
        var data = this.Data as ItemData_Weapon;
        return _gems.Count < data.Tier;
    }
}
