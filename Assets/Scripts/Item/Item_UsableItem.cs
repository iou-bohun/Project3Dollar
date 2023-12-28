using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item_UsableItem : Item
{
    public ItemData_UsableItem UsableItemData { get; private set; }
    
    public int Amount {  get; private set; }

    public int MaxAmount => UsableItemData.MaxAmount;
    
    public Item_UsableItem(ItemData_UsableItem data, int amount = 1): base(data) 
    { 
        UsableItemData = data;
        SetAmount(amount);
    } 

    public void SetAmount(int amount)
    {
        Amount = Mathf.Clamp(amount, 0, MaxAmount);
    }
}
