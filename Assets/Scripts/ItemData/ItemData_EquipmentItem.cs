using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemData_EquipmentItem : ItemData
{
    public int Tier => _tier;

    // ������ Ƽ��
    [SerializeField]
    private int _tier;
}
