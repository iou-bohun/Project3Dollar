using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item_Potion_", menuName = "ItemData/Potion", order = 3)]
public class ItemData_HealPotion : ItemData_UsableItem
{
    public float HealValue => _healValue;
    public Potion PotionFunc => potionFunction;

    [SerializeField]
    private float _healValue;

    [SerializeReference]
    private Potion potionFunction;

    public override Item CreateItem()
    {
        return new Item_HealPotion(this);
    }

    public override void Use()
    {
        throw new System.NotImplementedException();
    }
}
