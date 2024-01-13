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
        var weapon = _playerEquipment.GetMyWeapon();
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
        var rings = _playerEquipment.GetMyRings();
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

    private void UpdateCharmSlot()
    {
        var charm = _playerEquipment.GetMyCharm();
        if (charm != null)
        {
            _charmSlotUI.SetItem(charm.Data.Icon);
        }
        else
        {
            _charmSlotUI.SetItem(null);
            Debug.Log("peu null");
        }
    }

    //private void ClearSlot()
    //{
    //    for (int i = 0; i < _ringSlotUI.Length; i++)
    //    {
    //        _gemSlotUI[i].SetItem(null);
    //    }
    //}

    public void Equip(Item item, int index = -1)
    {
        if (item is Item_Weapon)
        {
            _playerEquipment.SetMyWeapon(item as Item_Weapon);
            _weaponSlotUI.SetItem(item.Data.Icon);
            var weapon = (Item_Weapon)item;
            //ClearSlot();
        }
        else if(item is Item_Ring)
        {
            _playerEquipment.SetMyRing(item as Item_Ring, index);
            _ringSlotUI[index].SetItem(item.Data.Icon);
            UpdateRingSlot();
        }
        else if(item is Item_Charm)
        {
            _playerEquipment.SetMyCharm(item as Item_Charm);
            UpdateCharmSlot();
        }
    }

    public Item Remove(int index)
    {
        Item item = null;
        if(index / defaultIndex == 1)
        {
            item = _playerEquipment.GetMyWeapon();
            _playerEquipment.SetMyWeapon(null);
            UpdateWeaponSlot();
        }
        else if(index / defaultIndex == 2)
        {
            item = _playerEquipment.GetMyRing(index % defaultIndex);
            _playerEquipment.SetMyRing(null, index %  defaultIndex);
            UpdateRingSlot();
        }
        else if(index / defaultIndex == 3)
        {
            item = _playerEquipment.GetMyCharm();
            _playerEquipment.SetMyCharm(null);
            UpdateCharmSlot();
        }
        return item;
    }

    public Item GetPlayerWeapon()
    {
        return _playerEquipment.GetMyWeapon();
    }

    public Item GetPlayerCharm()
    {
        return _playerEquipment.GetMyCharm();
    }

    public int FindEmptyRIngSlotIndex()
    {
        Item_Ring[] rings = _playerEquipment.GetMyRings();
        for (int i = 0; i < rings.Length; i++)
        {
            if (rings[i] == null ) return i;
        }
        return -1;
    }
}
