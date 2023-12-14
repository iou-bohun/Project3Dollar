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
    private SlotUI _charmSlotUI;

    [SerializeField]
    private SlotUI[] _gemSlotUI;

    private void Awake()
    {
        InitSlotUIIndex();
        InitSlotUI();
    }

    private void InitSlotUIIndex() 
    {
        _weaponSlotUI.SetSlotIndex(10000);
        for (int i = 0; i < _gemSlotUI.Length; i++)
        {
            _gemSlotUI[i].SetSlotIndex(20000 + i);
        }
        _charmSlotUI.SetSlotIndex(30000);
    }

    private void InitSlotUI()
    {
        UpdateWeaponSlot();
        UpdateGemSlot();
    }
    // Start is called before the first frame update
    void Start()
    {
        
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

    public Item GetPlayerWeapon()
    {
        return _playerEquipment.getMyWeapon();
    }

    public Item GetPlayerCharm()
    {
        return _playerEquipment.getMyCharm();
    }
}
