using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item_Ring", menuName = "ItemData/Ring", order = 2)]
public class ItemData_Ring : ItemData_EquipmentItem
{
    public override Item CreateItem()
    {
        return new Item_Ring(this);
    }
}
