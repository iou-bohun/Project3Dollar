using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item_Weapon", menuName = "ItemData/Weapon", order = 1)]
public class ItemData_Weapon : ItemData_EquipmentItem
{
    public int Damage => _damage;

    // 무기 데미지
    [SerializeField]
    private int _damage;

    public override Item CreateItem()
    {
        return new Item_Weapon(this);
    }
}
