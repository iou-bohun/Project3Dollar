using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FirstButtonEvent : EventButton
{
    private void OnEnable()
    {
        FadeButton();
        SetText(2);
    }
}
