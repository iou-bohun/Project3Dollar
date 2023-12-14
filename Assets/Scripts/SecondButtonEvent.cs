using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SecondButtonEvent : EventButton
{
    private void OnEnable()
    {
        FadeButton();
        SetText(2);
    }

    public void ButttonClick()
    {
        
    }
}
