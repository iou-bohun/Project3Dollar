using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [Header("Slots")]
    [SerializeField]
    private Transform weaponSlotParent;
    [SerializeField]
    private Transform ringSlotParent;
    [SerializeField]
    private Transform charmSlotParent;
    [SerializeField]
    private SlotUI[] slots;


    [SerializeField]
    private Inventory _inventory;
    [SerializeField]
    private ItemDescriptionUI _itemDescription;
    [SerializeField]
    private OptionPopupUI _optionPopupUI;
    [SerializeField]
    private PlayerEquipmentUI _playerEquipmentUI;
    [SerializeField]
    private Button _equipButton;
    [SerializeField]
    private Button _removeButton;
    [SerializeField]
    private Button _unequipButton;
    [SerializeField]
    private TMP_Text potionAmountText;


    private GraphicRaycaster _gr;
    private PointerEventData _ped;
    private List<RaycastResult> _rrList;

    private SlotUI selectedSlot;

    private int selectedOptionPopupIndex;


#if UNITY_EDITOR
    private void OnValidate()
    {
        List<SlotUI> list = new List<SlotUI>();
        list.AddRange(weaponSlotParent.GetComponentsInChildren<SlotUI>());
        list.AddRange(ringSlotParent.GetComponentsInChildren<SlotUI>());
        list.AddRange(charmSlotParent.GetComponentsInChildren<SlotUI>());
        slots = list.ToArray();
    }
#endif

    private void Init()
    {
        TryGetComponent(out _gr);
        if (_gr == null)
            _gr = gameObject.AddComponent<GraphicRaycaster>();

        _ped = new PointerEventData(EventSystem.current);
        _rrList = new List<RaycastResult>(10);
    }

    private void InitSlot()
    {
        int i;
        for (i = 0; i < 60; i++)
            slots[i].SetSlotIndex(i);
    }

    private void Awake()
    {
        Init();
        InitSlot();
    }

    // Start is called before the first frame update
    void Start()
    {
        var equipButton = _equipButton.GetComponent<Button>();
        var removeButton = _removeButton.GetComponent<Button>();
        var unequipButton = _unequipButton.GetComponent<Button>();

        removeButton.onClick.AddListener(RemoveItemFromSlot);
        equipButton.onClick.AddListener(EquipItemFromSlot);
        unequipButton.onClick.AddListener(UnequipItemFromSlot);
    }

    // Update is called once per frame
    void Update()
    {
        _ped.position = Input.mousePosition;
        OnRightClick();
        OnLeftClick();
        
    }
    
    private T RaycastAndGetFirstComponent<T>() where T : Component
    {
        _rrList.Clear();

        _gr.Raycast(_ped, _rrList);

        if (_rrList.Count == 0)
            return null;

        return _rrList[0].gameObject.GetComponent<T>();
    }

    private void OnLeftClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            selectedSlot = RaycastAndGetFirstComponent<SlotUI>();

            if (selectedSlot != null && selectedSlot.HasItem)
            {
                var data = _inventory.GetItemData(selectedSlot.Index);
                if(data is ItemData_Weapon)
                {
                    _itemDescription.SetWeaponDescription(data as ItemData_Weapon);
                }
                else if(data is ItemData_Ring)
                {
                    _itemDescription.SetRingDescriptipon(data as ItemData_Ring);
                }
                
            }
        }
    }

    private void OnRightClick()
    {
        if (Input.GetMouseButtonDown(1))
        {
            selectedSlot = RaycastAndGetFirstComponent<SlotUI>();

            if (selectedSlot != null && selectedSlot.HasItem)
            {
                if(selectedSlot.Index <= slots.Length)
                {
                    Debug.Log(selectedSlot.Index);
                    _optionPopupUI.SetPopupUIRect(selectedSlot.transform);
                    selectedOptionPopupIndex = selectedSlot.Index;
                    _optionPopupUI.Show();
                    _optionPopupUI.DisableUnEquipButton();
                }
                else
                {
                    Debug.Log(selectedSlot.Index);
                    _optionPopupUI.SetPopupUIRect(selectedSlot.transform);
                    selectedOptionPopupIndex = selectedSlot.Index;
                    _optionPopupUI.Show();
                    _optionPopupUI.DisableEquipButton();
                }
            }
        }
    }

    private void EquipItemFromSlot()
    {
        var item = _inventory.GetItem(selectedOptionPopupIndex);
        if(item != null) 
        {
            if(item is Item_Weapon)
            {
                Debug.Log(item.Data.name);

                var prevPlayerWeapon = _playerEquipmentUI.GetPlayerWeapon() as Item_Weapon;
                _playerEquipmentUI.Equip(item);
                RemoveItemFromSlot();
                if(prevPlayerWeapon != null)
                {
                    Debug.Log(prevPlayerWeapon.Data.name);  
                    _inventory.Add(prevPlayerWeapon, selectedOptionPopupIndex);
                }
            }
            else if(item is Item_Ring)
            {
                Debug.Log(item.Data.name);
                int index = _playerEquipmentUI.FindEmptyRIngSlotIndex();

                if (index == -1)
                {
                    Debug.Log("빈 슬롯이 없습니다.");
                }
                else
                {
                    _playerEquipmentUI.Equip(item, index);
                    RemoveItemFromSlot();
                    Debug.Log(index);
                }
            }
            else if(item is Item_Charm)
            {
                Debug.Log(item.Data.name);

                var prevPlayerCharm = _playerEquipmentUI.GetPlayerCharm() as Item_Charm;
                _playerEquipmentUI.Equip(item);
                RemoveItemFromSlot();
                if (prevPlayerCharm != null)
                {
                    Debug.Log(prevPlayerCharm.Data.name);
                    _inventory.Add(prevPlayerCharm, selectedOptionPopupIndex);
                }
            }
        }
        _optionPopupUI.Hide();
    }

    public void RemoveItemFromSlot()
    {
        if(selectedOptionPopupIndex <= slots.Length * 3)
        {
            _inventory.Remove(selectedOptionPopupIndex);
            _optionPopupUI.Hide();
        }
        else
        {
            _playerEquipmentUI.Remove(selectedOptionPopupIndex);
            _optionPopupUI.Hide();
        }
    }

    public void UnequipItemFromSlot()
    {
        ItemData.Type type;
        if (selectedOptionPopupIndex / _playerEquipmentUI.defaultIndex == 1) type = ItemData.Type.Weapon;
        else if (selectedOptionPopupIndex / _playerEquipmentUI.defaultIndex == 2) type = ItemData.Type.Ring;
        else type = ItemData.Type.Charm;

        int i = _inventory.FindEmptySlotIndex(type);
        
        if(i != -1)
        {
            var item = _playerEquipmentUI.Remove(selectedOptionPopupIndex);
            _inventory.Add(item, i);
        }
        else
        {
            Debug.Log("인벤토리에 남는 슬롯이 없습니다");
        }
        _optionPopupUI.Hide();
    }

    public void SetInventoryReference(Inventory invetory)
    {
        _inventory = invetory;
    }

    public void SetItemIcon(int index, Sprite icon)
    {
        slots[index].SetItem(icon);
    }

    public void RemoveItem(int index)
    {
        slots[index].RemoveItem();
    }

    public void UpdatePotionSlot(int amount)
    {
        potionAmountText.text = amount.ToString();
    }
}
