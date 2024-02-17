using DG.Tweening;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager_ : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] DTxt;
    public string eventName;
    public GameObject layout;

    public GameObject imageObject;
    public GameObject[] buttonObject;
    public Sprite eventIImg;
    Image thisImg;

    float dialogueDuration = 1.4f;

    private void Awake()
    {
       eventName = GetRandomEvent();
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
        yield return new WaitForSeconds(dialogueDuration*DialogudManager.instance.TheDialogue.contexts.Length);
        Debug.Log(DialogudManager.instance.TheDialogue.contexts.Length);
        imageObject.SetActive(true);
        thisImg.DOFade(1.0f, 2f);
        Invoke("SpawnButton", 1f);
    }
    public void SpawnButton()
    {
        for (int i = 0; i < DialogudManager.instance.TheDialogue.buttonCount; i++)
        {
           Instantiate(buttonObject[i], layout.transform);
        }
    }

    IEnumerator Typing()
    {
        for(int i=0; i<DialogudManager.instance.TheDialogue.contexts.Length; i++)
        {
            DTxt[i].text = DialogudManager.instance.TheDialogue.contexts[i];
            TMPText(DTxt[i], dialogueDuration);
            yield return new WaitForSeconds(dialogueDuration);
            
        }
    }

    public void TMPText(TextMeshProUGUI text, float duration)
    {
        text.maxVisibleCharacters = 0;
        DOTween.To(x => text.maxVisibleCharacters = (int)x, 0f, text.text.Length, duration);
    }

    String GetRandomEvent()
    {
        string[] eventNameArray = { "FindWeagon","HelpVictim","Skeleton",
            "SkeletonHood", "Zombie","Ghoul","SkeletonWizard","SkeletonKnight","Test","Test1"};
        int randomIndex = UnityEngine.Random.Range(0, eventNameArray.Length);
        return eventNameArray[randomIndex];
    }
}
