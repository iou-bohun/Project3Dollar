using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item_Gem", menuName = "ItemData/Gem", order = 2)]
public class ItemData_Gem : ItemData_EquipmentItem
{
    public override Item CreateItem()
    {
        return new Item_Gem(this);
    }
}
