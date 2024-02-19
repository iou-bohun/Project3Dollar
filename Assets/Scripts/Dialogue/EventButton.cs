using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class EventButton : MonoBehaviour
{

    protected void FadeButton()
    {
        Color color = this.GetComponent<Image>().color;
        color.a = 0.0f;
        this.GetComponent<Image>().DOFade(1.0f, 2f);
    }

    protected void SetText(int num)
    {
        GetComponentInChildren<TextMeshProUGUI>().text = DialogudManager.instance.TheDialogue.buttons[num];
    }

    public void ButtonClick(string text)
    {
        switch (text)
        {
            case "��������":
                Run();
                break;
            case "�����Ѵ�":
                Run();
                break;
            case "�ο��":
                Fight();
                break;
            case "�����Ѵ�":
                Examine();
                break;
        }
    }
    public void Run()
    {
        SceneManager.LoadScene("EveneScene 1");
    }

    private void Fight()
    {
        SceneManager.LoadScene("BattleReDesign");

    }

    private void Examine()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
