using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PotionFunc/HealPotion", order = 0)]
public class Potion: ScriptableObject 
{
    public virtual void Use(int healAmount) { }
}
