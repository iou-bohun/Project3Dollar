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
        text = DialogudManager.instance.TheDialogue.buttons[2];
        FadeButton();
        SetText(2);
    }

    public void ButttonClick()
    {
        switch (text)
        {
            case "도망간다":
                Run();
                break;
            case "무시한다":
                Run();
                break;
            default:
                Debug.Log("Bug");
                break;
        }
    }

   private void Run()
    {
        Debug.Log("도망간다");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
