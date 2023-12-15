using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerEquipmentUI : MonoBehaviour
{
    [SerializeField]
    private PlayerEquipment _playerEquipment;

    [SerializeField]
    private SlotUI _weaponSlotUI;

    [SerializeField] 
    private SlotUI _charmSlotUI;

    [SerializeField]
    private SlotUI[] _gemSlotUI;

    public int defaultIndex = 10000;

    private void Start()
    {
        InitSlotUIIndex();
        InitSlotUI();
    }

    private void InitSlotUIIndex() 
    {
        _weaponSlotUI.SetSlotIndex(defaultIndex);
        for (int i = 0; i < _gemSlotUI.Length; i++)
        {
            _gemSlotUI[i].SetSlotIndex(defaultIndex * 2 + i);
        }
        _charmSlotUI.SetSlotIndex(defaultIndex * 3);
    }

    private void InitSlotUI()
    {
        UpdateWeaponSlot();
        UpdateGemSlot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateWeaponSlot()
    {
        var weapon = _playerEquipment.getMyWeapon();
        if (weapon != null)
        {
            _weaponSlotUI.SetItem(weapon.Data.Icon);
        }
        else
        {
            _weaponSlotUI.SetItem(null);
            Debug.Log("peu null");
        }
    }

    private void UpdateGemSlot()
    {
        var weapon = _playerEquipment.getMyWeapon();
        int i = 0;
        if (weapon != null)
        {
            foreach (Item gem in weapon._gems)
            {
                _gemSlotUI[i++].SetItem(gem.Data.Icon);
            }
            while (i < 3)
            {
                _gemSlotUI[i].SetItem(null);
                i++;
            }
        }
        else
        {
            ClearSlot();
        }
    }

    private void ClearSlot()
    {
        for (int i = 0; i < _gemSlotUI.Length; i++)
        {
            _gemSlotUI[i].SetItem(null);
        }
    }

    public void Equip(Item item)
    {
        if (item is Item_Weapon)
        {
            _playerEquipment.setMyWeapon(item);
            _weaponSlotUI.SetItem(item.Data.Icon);
            var weapon = (Item_Weapon)item;
            ClearSlot();
            UpdateGemSlot();
        }
        else if (item is Item_Gem)
        {
            var weapon = _playerEquipment.getMyWeapon();
            if (weapon != null)
            {
                weapon.AddGem(item);
                ClearSlot();
                UpdateGemSlot();
            }
        }
    }

    public Item Remove(int index)
    {
        Item item = null;
        if(index / defaultIndex == 1)
        {
            item = _playerEquipment.getMyWeapon();
            _playerEquipment.setMyWeapon(null);
            UpdateWeaponSlot();
            UpdateGemSlot();
        }
        else if(index / defaultIndex == 2)
        {
            item = _playerEquipment.getMyWeapon().RemoveGem(index % defaultIndex);
            UpdateGemSlot();
        }
        else if(index / defaultIndex == 3)
        {

        }
        return item;
    }

    public Item GetPlayerWeapon()
    {
        return _playerEquipment.getMyWeapon();
    }

    public Item GetPlayerCharm()
    {
        return _playerEquipment.getMyCharm();
    }
}
