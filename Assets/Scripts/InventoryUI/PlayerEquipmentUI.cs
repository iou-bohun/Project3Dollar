using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentUI : MonoBehaviour
{
    [SerializeField]
    private PlayerEquipment _playerEquipment;

    [SerializeField]
    private SlotUI _weaponSlotUI;

    [SerializeField]
    private SlotUI[] _gemSlotUI;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Equip(Item item)
    {
        if(item is Item_Weapon)
        {
            _playerEquipment.setMyWeapon(item);
            _weaponSlotUI.SetItem(item.Data.Icon);
            var weapon = (Item_Weapon)item;
            ClearSlot();
            UpdateGemSlot(weapon);
        }
        else if(item is Item_Gem)
        {
            var weapon = _playerEquipment.getMyWeapon();
            if(weapon != null)
            {
                weapon.AddGem(item);
                ClearSlot();
                UpdateGemSlot(weapon);
            }
        }
    }

    private void UpdateGemSlot(Item_Weapon weapon)
    {
        int i = 0;
        foreach(Item gem in weapon._gems)
        {
            _gemSlotUI[i++].SetItem(gem.Data.Icon);
        }
    }

    private void ClearSlot()
    {
        for (int i = 0; i < _gemSlotUI.Length; i++)
        {
            _gemSlotUI[i].SetItem(null);
        }
    }
}
