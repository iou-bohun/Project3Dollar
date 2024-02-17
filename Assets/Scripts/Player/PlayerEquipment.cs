using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType
{
    Slash,
    Pierce,
    Strike
}

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
        myRing = new Item_Ring[3] { null, null, null };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Item_Weapon GetMyWeapon()
    {
        if (myWeapon is not null)
        {
            Debug.Log(myWeapon.Data.name);
            return myWeapon;
        }
        else return null;
    }

    public Item GetMyCharm() => myCharm;

    public Item_Ring[] GetMyRings() => myRing;

    public Item_Ring GetMyRing(int index) => myRing[index];
    public void SetMyWeapon(Item_Weapon weapon) => myWeapon = weapon;

    public void SetMyCharm(Item_Charm charm) => myCharm = charm;

    public void SetMyRing(Item_Ring ring, int index)
    {
        myRing[index] = ring;
    }

    public float GetPlayerAttackValue(AttackType type)
    {
        ItemData_Weapon data = myWeapon.Data as ItemData_Weapon;

        float attackValue = data.Damage;

        float attackTypeValue = 0f;

        switch (type)
        {
            case AttackType.Slash:
                attackTypeValue = data.SlashValue;
                break;
            case AttackType.Pierce:
                attackTypeValue = data.PierceValue;
                break;
            case AttackType.Strike:
                attackTypeValue = data.StrikeValue;
                break;
        }

        return attackValue * attackTypeValue;
    }

    public void Attack()
    {
        if (myWeapon == null)
            return;

        Debug.Log(GetPlayerAttackValue(AttackType.Slash));
        myWeapon.OnUseItem(1);
    }
}
