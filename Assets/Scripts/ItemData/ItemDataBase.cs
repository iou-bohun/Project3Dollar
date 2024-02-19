using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : MonoBehaviour
{
    [SerializeField] private ItemData_Weapon[] weaponDatas;
    [SerializeField] private ItemData_Ring[] ringDatas;
    [SerializeField] private ItemData_Charm[] charmDatas;
    private Dictionary<int, ItemData> _itemDatasDictionary;

    public static ItemDataBase instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _itemDatasDictionary = new Dictionary<int, ItemData>();
        foreach (var cardData in weaponDatas)
        {
            _itemDatasDictionary.Add(cardData.name.GetHashCode(), cardData);
        }

        foreach (var statusCardData in ringDatas)
        {
            _itemDatasDictionary.Add(statusCardData.name.GetHashCode(), statusCardData);
        }

        foreach (var defaultCardData in charmDatas)
        {
            _itemDatasDictionary.Add(defaultCardData.name.GetHashCode(), defaultCardData);
        }
    }


    //public Card GetCard(int index)
    //{
    //    return cardDatas[index].CreateCard();
    //}

    public Item GetItem(string name)
    {
        return _itemDatasDictionary[name.GetHashCode()].CreateItem();
    }

    public Item GetRandomRewardCard()
    {
        return weaponDatas[Random.Range(0, weaponDatas.Length)].CreateItem();
    }
}
