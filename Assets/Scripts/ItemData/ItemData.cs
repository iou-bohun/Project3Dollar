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

    // ������ ID
    [SerializeField]
    private int _id;
    // ������ �̸�
    [SerializeField] 
    private string _name;    
    // ������ ����
    [Multiline]
    [SerializeField] 
    private string _description; 
    // ������ ������
    [SerializeField] 
    private Sprite _icon; 

    public abstract Item CreateItem();
}
