using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    [SerializeField]
    private Item myWeapon;

    [SerializeField]
    private Item myCharm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Item getMyWeapon() => myWeapon;

    public Item getCharm() => myCharm;

    public void setMyWeapon(Item weapon) => myWeapon = weapon;

    public void setMyCharm(Item charm) => myCharm = charm;

    public void AddGemInMyWeapon(Item gem)
    {
        var weapon = myWeapon as Item_Weapon;

        weapon.AddGem(gem);
    }
}
