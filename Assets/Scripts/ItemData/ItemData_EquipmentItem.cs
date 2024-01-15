using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemData_EquipmentItem : ItemData
{
    public int Tier => _tier;

    // 아이템 티어
    [SerializeField]
    private int _tier;
}
