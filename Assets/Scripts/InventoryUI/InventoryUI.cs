using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private Transform slotParent;
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


    private GraphicRaycaster _gr;
    private PointerEventData _ped;
    private List<RaycastResult> _rrList;

    private SlotUI selectedSlot;
    private OptionPopupUI optionPopupUI;

    private int selectedOptionPopupIndex;


#if UNITY_EDITOR
    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<SlotUI>();
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
        for (int i = 0; i < 20; i++)
        {
            slots[i].SetSlotIndex(i);
        }
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

        removeButton.onClick.AddListener(RemoveItemFromSlot);
        equipButton.onClick.AddListener(EquipItemFromSlot);
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
                _itemDescription.SetDescriptiponText(data.Description);
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
                _optionPopupUI.SetPopupUIRect(selectedSlot.transform);
                //_optionPopupUI.SetIndex(selectedSlot.Index);
                selectedOptionPopupIndex = selectedSlot.Index;
                _optionPopupUI.Show();
            }
        }


    }

    private void EquipItemFromSlot()
    {
        var item = _inventory.GetItem(selectedOptionPopupIndex);
        if(item != null) 
        {
            Debug.Log(item.Data.name);
            _playerEquipmentUI.Equip(item);
        }
        _optionPopupUI.Hide();
    }
    public void RemoveItemFromSlot()
    {
        _inventory.Remove(selectedOptionPopupIndex);
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
}
