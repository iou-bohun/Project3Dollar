using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerBattle : MonoBehaviour
{
    public void Attack()
    {
        transform.DOMoveX(0.14f, 0.2f).SetEase(Ease.InElastic,0,5f).SetLoops(2,LoopType.Yoyo);
    }
}
