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
    private SlotUI[] _ringSlotUI;

    public int defaultIndex = 10000;

    private void Start()
    {
        InitSlotUIIndex();
        InitSlotUI();
    }

    private void InitSlotUIIndex() 
    {
        _weaponSlotUI.SetSlotIndex(defaultIndex);
        for (int i = 0; i < _ringSlotUI.Length; i++)
        {
            _ringSlotUI[i].SetSlotIndex(defaultIndex * 2 + i);
        }
        _charmSlotUI.SetSlotIndex(defaultIndex * 3);
    }

    private void InitSlotUI()
    {
        UpdateWeaponSlot();
        UpdateRingSlot();
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

    private void UpdateRingSlot()
    {
        var rings = _playerEquipment.getMyRing();
        for (int i = 0; i < _ringSlotUI.Length; i++)
        {
            if (rings[i] != null)
            {
                _ringSlotUI[i].SetItem(rings[i].Data.Icon);
            }
            else
            {
                _ringSlotUI[i].SetItem(null);
            }
        }
    }

    //private void ClearSlot()
    //{
    //    for (int i = 0; i < _ringSlotUI.Length; i++)
    //    {
    //        _gemSlotUI[i].SetItem(null);
    //    }
    //}

    public void Equip(Item item)
    {
        if (item is Item_Weapon)
        {
            _playerEquipment.setMyWeapon(item as Item_Weapon);
            _weaponSlotUI.SetItem(item.Data.Icon);
            var weapon = (Item_Weapon)item;
            //ClearSlot();
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
        }
        else if(index / defaultIndex == 2)
        {
            
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

    public int FindEmptyRIngSlotIndex()
    {
        for (int i = 0; i < _ringSlotUI.Length; i++)
        {
            if (!_ringSlotUI[i].HasItem) return i;
        }
        return -1;
    }
}
