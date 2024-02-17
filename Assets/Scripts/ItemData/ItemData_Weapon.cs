using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item_Weapon", menuName = "ItemData/Weapon", order = 1)]
public class ItemData_Weapon : ItemData_EquipmentItem
{
    public int Damage => _damage;

    public int MaxDurability => _maxDurability;

    public float SlashValue => _slashValue;
    public float PierceValue => _pierceValue;
    public float StrikeValue => _strikeValue;

    // 무기 데미지
    [SerializeField]
    private int _damage;

    [SerializeField]
    private float _slashValue;

    [SerializeField]
    private float _pierceValue;

    [SerializeField]
    private float _strikeValue;

    [SerializeField]
    private int _maxDurability;
    public override Item CreateItem()
    {
        return new Item_Weapon(this);
    }
}
