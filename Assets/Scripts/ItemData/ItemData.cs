using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemData : ScriptableObject
{
    public int Id => _id;
    public string Name => _name;
    public string Description => _description;
    public Sprite Icon => _icon;

    public enum Type
    {
        Weapon,
        Ring,
        Charm,
        Potion
    }

    public Type type;

    // 아이템 ID
    [SerializeField]
    private int _id;
    // 아이템 이름
    [SerializeField] 
    private string _name;    
    // 아이템 설명
    [Multiline]
    [SerializeField] 
    private string _description; 
    // 아이템 아이콘
    [SerializeField] 
    private Sprite _icon; 

    public abstract Item CreateItem();
}
