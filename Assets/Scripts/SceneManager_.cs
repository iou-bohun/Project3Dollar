using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager_ : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI firstText;
    public string eventName;
    public GameObject layout;

    public GameObject imageObject;
    public GameObject[] buttonObject;
    public Sprite eventIImg;
    Image thisImg;

    private void Awake()
    {
        eventName = GetRandonEvent();
    }

    private void Start()
    {

        Sprite sprite = Resources.Load<Sprite>("Sprite/" + eventName);
        thisImg = imageObject.GetComponent<Image>();
        thisImg.sprite = sprite;
        StartCoroutine("Typing");
        StartCoroutine("imageActive");

    }
    IEnumerator imageActive()
    {
        yield return new WaitForSeconds(1.4f);
        imageObject.SetActive(true);
        thisImg.DOFade(1.0f, 2f);
        Invoke("SpawnButton", 1f);
    }
    public void SpawnButton()
    {
        for (int i = 0; i < DialogudManager.instance.TheDialogue.buttonCount - 1; i++)
        {
            Instantiate(buttonObject[i], layout.transform);
        }
    }

    IEnumerator Typing()
    {
        firstText.text = DialogudManager.instance.TheDialogue.contexts[0];
        TMPText(firstText, 2f);
        yield return new WaitForSeconds(1.5f);
    }

    public void TMPText(TextMeshProUGUI text, float duration)
    {
        text.maxVisibleCharacters = 0;
        DOTween.To(x => text.maxVisibleCharacters = (int)x, 0f, text.text.Length, duration);
    }

    String GetRandonEvent()
    {
        string[] eventNameArray = { "FindWeagon","HelpVictim","Skeleton",
            "SkeletonHood", "Zombie","Ghoul","SkeletonWizard","SkeletonKnight",};
        int randomIndex = UnityEngine.Random.Range(0, eventNameArray.Length);
        return eventNameArray[randomIndex];
    }
}
