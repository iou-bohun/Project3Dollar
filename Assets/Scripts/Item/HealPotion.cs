using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPotion : Potion
{
    public override void Use(int healAmount)
    {
        Debug.Log($"{healAmount}��ŭ ȸ����");
    }
}
