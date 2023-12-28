using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class FirstButtonEvent : EventButton
{
    private string text;
    private void OnEnable()
    {
        text = DialogudManager.instance.TheDialogue.buttons[0];
        FadeButton();
        SetText(0);
    }

    public void ButtonClick()
    {
        switch (text)
        {
            case "�ο��":
                Fight();
                break;
            case "�����Ѵ�":
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
        SceneManager.LoadScene("SampleScene");
    }

    private void Examine()
    {
        Debug.Log("Examine");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
