using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponListScroll : MonoBehaviour
{
    [SerializeField]
    private Transform slotParent;
    [SerializeField]
    private SlotUI[] slots;

    [SerializeField]
    private Inventory _inventory;
    [SerializeField]
    private OptionPopupUI _optionPopupUI;

    private GraphicRaycaster _gr;
    private PointerEventData _ped;
    private List<RaycastResult> _rrList;
    private SlotUI selectedSlot;

    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<SlotUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateAllSlot();
        Init();
        InitSlot();
    }

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
        for (i = 0; i < _inventory.slotNum; i++)
            slots[i].SetSlotIndex(i);
    }

    // Update is called once per frame
    void Update()
    {
        _ped.position = Input.mousePosition;
        OnRightClick();
    }

    public void UpdateAllSlot()
    {
        Item[] items = _inventory.GetItems();
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != null)
                slots[i].SetItem(items[i].Data.Icon);
            else
                slots[i].SetItem(null);
        }
    }

    private T RaycastAndGetFirstComponent<T>() where T : Component
    {
        _rrList.Clear();

        _gr.Raycast(_ped, _rrList);

        if (_rrList.Count == 0)
            return null;

        return _rrList[0].gameObject.GetComponent<T>();
    }

    private void OnRightClick()
    {
        if (Input.GetMouseButtonDown(1))
        {
            selectedSlot = RaycastAndGetFirstComponent<SlotUI>();

            if (selectedSlot != null && selectedSlot.HasItem)
            {
                if (selectedSlot.Index <= slots.Length)
                {
                    Debug.Log(selectedSlot.Index);
                    _optionPopupUI.SetPopupUIRect(selectedSlot.transform);
                    //selectedOptionPopupIndex = selectedSlot.Index;
                    _optionPopupUI.Show();
                    _optionPopupUI.DisableUnEquipButton();
                }
                else
                {
                    Debug.Log(selectedSlot.Index);
                    //_optionPopupUI.SetPopupUIRect(selectedSlot.transform);
                    //selectedOptionPopupIndex = selectedSlot.Index;
                    //_optionPopupUI.Show();
                    //_optionPopupUI.DisableEquipButton();
                }
            }
            else
            {
                Debug.Log("슬롯을 못찾음");
            }
        }
    }
}
