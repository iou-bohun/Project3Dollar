using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class EventButton : MonoBehaviour
{
    
    protected void FadeButton()
    {
        Color color = this.GetComponent<Image>().color;
        color.a = 0.0f;
        this.GetComponent<Image>().DOFade(1.0f, 2f);
    }

    protected  void SetText(int num)
    {
        GetComponentInChildren<TextMeshProUGUI>().text = DialogudManager.instance.TheDialogue.buttons[num];
    }
}
