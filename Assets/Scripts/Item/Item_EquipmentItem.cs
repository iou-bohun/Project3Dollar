using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item_EquipmentItem : Item
{
    public ItemData_EquipmentItem EquipmentItemData { get; private set; }

    public Item_EquipmentItem(ItemData_EquipmentItem data) : base(data)
    {
        EquipmentItemData = data;
    }
}
