using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Weapon : Item_EquipmentItem
{
    [SerializeField]
    private List<Item> _gems;

    public Item_Weapon(ItemData_Weapon data) : base(data) { }

    public void AddGem(Item gem)
    {
        if (_gems.Count < this.EquipmentItemData.Tier)
        {
            _gems.Add(gem);
        }
    }

    public Item Remove(int index)
    {
        if (_gems[index] != null)
        {
            Item gem = _gems[index];
            _gems.RemoveAt(index);
            return gem;
        }
        return null;
    }
}
