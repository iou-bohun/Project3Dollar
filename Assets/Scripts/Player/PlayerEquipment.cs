using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    [SerializeField]
    private Item_Weapon myWeapon;

    [SerializeField]
    private Item myCharm;

    private void Awake()
    {
        myWeapon = null;
        myCharm = null;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Item_Weapon getMyWeapon() => myWeapon;

    public Item getMyCharm() => myCharm;

    public void setMyWeapon(Item weapon) => myWeapon = weapon as Item_Weapon;

    public void setMyCharm(Item charm) => myCharm = charm;

    public void AddGemInMyWeapon(Item gem)
    {
        var weapon = myWeapon as Item_Weapon;

        weapon.AddGem(gem);
    }
}
