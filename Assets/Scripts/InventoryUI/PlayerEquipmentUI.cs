using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentUI : MonoBehaviour
{
    [SerializeField]
    private PlayerEquipment _playerEquipment;

    [SerializeField]
    private SlotUI _weaponSlotUI;

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
        }
    }
}
