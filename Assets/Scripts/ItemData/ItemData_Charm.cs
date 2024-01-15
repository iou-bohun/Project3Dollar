using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item_Charm", menuName = "ItemData/Charm", order = 3)]
public class ItemData_Charm : ItemData_EquipmentItem
{
    public override Item CreateItem()
    {
        return new Item_Charm (this);
    }
}
