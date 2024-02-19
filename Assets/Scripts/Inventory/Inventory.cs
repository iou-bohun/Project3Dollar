using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.Port;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private Item[] _items;

    [SerializeField]
    private Item_HealPotion _healPotion;

    private InventoryUI _inventoryUI;

    public ItemData[] itemDatas;
    public ItemData _healPotionData;

    public int slotNum;

    private void Awake()
    {
        _items = new Item[slotNum * 3];

        var obj = FindObjectsOfType<Inventory>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _healPotion = _healPotionData.CreateItem() as Item_HealPotion;

        _healPotion.SetAmount(0);
        _inventoryUI.UpdatePotionSlot(_healPotion.Amount);

        for (int i = 0; i < itemDatas.Length; i++)
        {
            Add(itemDatas[i]);
        }
    }

    public int FindEmptySlotIndex(int startIndex = 0)
    {
        for (int i = startIndex; i < 20; i++)
            if (_items[i] == null)
                return i;
        return -1;
    }

    public int FindEmptySlotIndex(ItemData.Type type)
    {
        int time=0;
        if (type == ItemData.Type.Weapon)
        {
            time = 0;
        }
        else if (type == ItemData.Type.Ring) time = 1;
        else if (type == ItemData.Type.Charm) time = 2;
        
        for (int i = slotNum * time; i < slotNum * (time + 1); i++)
            if (_items[i] == null)
                return i;
        return -1;
    }

    private void UpdateSlot(int index)
    {

        Item item = _items[index];

        if(item != null)
        {
            _inventoryUI.SetItemIcon(index, item.Data.Icon);
        }
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

    public void UpdateAllSlot()
    {
        for (int i = 0; i < 20 * 3; i++)
        {
            UpdateSlot(i);
        }
    }

    // 아이템 추가 메소드
    public void Add(ItemData itemData, int amount = 1)
    {
        int index;

        if(itemData is ItemData_UsableItem)
        {
            if(itemData is ItemData_HealPotion healPotion)
            {
                _healPotion.SetAmount(_healPotion.Amount + amount);
                _inventoryUI.UpdatePotionSlot(_healPotion.Amount);
                Debug.Log(_healPotion.Amount);
            }
        }
        else
        {
            index = FindEmptySlotIndex(itemData.type);
            if (index != -1)
            {
                // 아이템을 생성하여 슬롯에 추가
                _items[index] = itemData.CreateItem();
                Debug.Log(index + ": " + itemData.Name);

                UpdateSlot(index);
            }
        }
        
    }

    public void Add(Item item, int index)
    {
        _items[index] = item;
        UpdateSlot(index);
    }

    public void Remove(int index)
    {
        _items[index] = null;
        _inventoryUI.RemoveItem(index);
    }

    // InventoryUI와 연결
    public void ConnectUI(InventoryUI inventoryUI)
    {
        _inventoryUI = inventoryUI;
        _inventoryUI.SetInventoryReference(this);
    }

    // Item array에서 ItemData 가져오기 
    public ItemData GetItemData(int index)
    {
        if (_items[index] == null) return null;

        return _items[index].Data;
    }

    public Item GetItem(int index)
    {
        if (_items[index] == null) return null;

        return _items[index];
    }

    public Item[] GetItems()
    {
        Item[] items = new Item[slotNum];
        for (int i = 0; i < slotNum; i++)
        {
            items[i] = GetItem(i);
        }
        return items;
    }

    // Test
    #region
    public void AddRandomItem()
    {
        int idx = Random.Range(0, itemDatas.Length);
        var data = itemDatas[idx];

        Add(data);
    }

    public void RemoveRandomItem()
    {
        int idx = Random.Range(0, 20);
        Remove(idx);
    }

    public void AddPotion()
    {
        Add(_healPotionData, Random.Range(1, 4));
    }
    #endregion
}
