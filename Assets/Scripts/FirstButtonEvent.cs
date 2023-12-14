using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FirstButtonEvent : EventButton
{
    private string text;
    private void OnEnable()
    {
        text = DialogudManager.instance.TheDialogue.buttons[1];
        FadeButton();
        SetText(1);
    }

    public void ButtonClick()
    {
        switch (text)
        {
            case "싸운다":
                Fight();
                break;
            case "조사한다":
                Examine();
                break;
            default:
                Debug.Log("Bug");
                break;
        }
    }

    private void Fight()
    {
        Debug.Log("Fight");
    }

    private void Examine()
    {
        Debug.Log("Examine");
    }
}
