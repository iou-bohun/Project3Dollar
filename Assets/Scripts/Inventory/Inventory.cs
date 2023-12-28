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

    [SerializeField]
    private InventoryUI _inventoryUI;

    public ItemData[] itemDatas;
    public ItemData _healPotionData;

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        _items = new Item[20];

        ItemData_HealPotion data = new ItemData_HealPotion();
        _healPotion = data.CreateItem() as Item_HealPotion;

        _healPotion.SetAmount(0);
        _inventoryUI.UpdatePotionSlot(_healPotion.Amount);

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

        if(item != null)
        {
            _inventoryUI.SetItemIcon(index, item.Data.Icon);
        }
        /*// 2. �� ������ ��� : ������ ����
        else
        {
            RemoveIcon();
        }*/

        // ���� : ������ �����ϱ�
        /*void RemoveIcon()
        {
            _inventoryUI.RemoveItem(index);
            _inventoryUI.HideItemAmountText(index); // ���� �ؽ�Ʈ �����
        }*/
    }

    private void UpdateAllSlot()
    {
        for (int i = 0; i < 20; i++)
        {
            UpdateSlot(i);
        }
    }

    // ������ �߰� �޼ҵ�
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
            index = FindEmptySlotIndex();
            if (index != -1)
            {
                // �������� �����Ͽ� ���Կ� �߰�
                _items[index] = itemData.CreateItem();

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

    // InventoryUI�� ����
    public void ConnectUI(InventoryUI inventoryUI)
    {
        _inventoryUI = inventoryUI;
        _inventoryUI.SetInventoryReference(this);
    }

    // Item array���� ItemData �������� 
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
