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
    }
    // Start is called before the first frame update
    void Start()
    {
        myWeapon = null;
        myCharm = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Item_Weapon getMyWeapon()
    {
        if (myWeapon is not null)
        {
            Debug.Log(myWeapon.Data.name);
            return myWeapon;
        }
        else return null;
    }


    public Item getMyCharm() => myCharm;

    public void setMyWeapon(Item weapon) => myWeapon = weapon as Item_Weapon;

    public void setMyCharm(Item charm) => myCharm = charm;

    public void AddGemInMyWeapon(Item gem)
    {
        var weapon = myWeapon as Item_Weapon;

        weapon.AddGem(gem);
    }
}
