using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item_UsableItem : Item
{
    public ItemData_UsableItem UsableItemData { get; private set; }
    public Item_UsableItem(ItemData_UsableItem data): base(data) 
    { 
        UsableItemData = data;
    } 
}
