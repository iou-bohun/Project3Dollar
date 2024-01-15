using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class SecondButtonEvent : EventButton
{
    private string text;
    private void OnEnable()
    {
        text = DialogudManager.instance.TheDialogue.buttons[1];
        FadeButton();
        SetText(1);
    }
    public void SecondButtonClick()
    {
        ButtonClick(text);
    }
}
