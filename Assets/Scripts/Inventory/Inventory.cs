using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.Port;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private Item[] _items;

    [SerializeField]
    private InventoryUI _inventoryUI;

    public ItemData[] itemDatas;

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        _items = new Item[20];

        for (int i = 0; i < itemDatas.Length; i++)
        {
            Add(itemDatas[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int FindEmptySlotIndex(int startIndex = 0)
    {
        for (int i = startIndex; i < 20; i++)
            if (_items[i] == null)
                return i;
        return -1;
    }

    private void UpdateSlot(int index)
    {

        Item item = _items[index];

        _inventoryUI.SetItemIcon(index, item.Data.Icon);
        /*// 2. 빈 슬롯인 경우 : 아이콘 제거
        else
        {
            RemoveIcon();
        }*/

        // 로컬 : 아이콘 제거하기
        /*void RemoveIcon()
        {
            _inventoryUI.RemoveItem(index);
            _inventoryUI.HideItemAmountText(index); // 수량 텍스트 숨기기
        }*/
    }

    public void Add(ItemData itemData)
    {
        int index;

        index = FindEmptySlotIndex();
        if (index != -1)
        {
            // 아이템을 생성하여 슬롯에 추가
            _items[index] = itemData.CreateItem();

            UpdateSlot(index);
        }
    }

    public void ConnectUI(InventoryUI inventoryUI)
    {
        _inventoryUI = inventoryUI;
        _inventoryUI.SetInventoryReference(this);
    }

    public ItemData GetItemData(int index)
    {
        if (_items[index] == null) return null;

        return _items[index].Data;
    }
}
