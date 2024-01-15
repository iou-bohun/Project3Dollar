using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemData_UsableItem : ItemData
{
    public abstract void Use();
    public int MaxAmount => _maxAmount;
    [SerializeField] 
    private int _maxAmount = 99;
}
