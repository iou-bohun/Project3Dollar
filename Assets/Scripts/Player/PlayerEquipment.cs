using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    [SerializeField]
    private Item_Weapon myWeapon;

    [SerializeField]
    private Item_Ring[] myRing;

    [SerializeField]
    private Item_Charm myCharm;

    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        myWeapon = null;
        myCharm = null;
        myRing = new Item_Ring[3];
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

    public Item_Ring[] getMyRing() => myRing;
    public void setMyWeapon(Item_Weapon weapon) => myWeapon = weapon;

    public void setMyCharm(Item_Charm charm) => myCharm = charm;

    public void setMyRing(Item_Ring ring)
    {

    }
}
