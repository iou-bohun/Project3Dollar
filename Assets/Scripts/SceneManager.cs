using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public string eventName;

    public GameObject imageObject;
    public Sprite eventIImg;
    Image thisImg;

    private void Start()
    {
        Sprite sprite = Resources.Load<Sprite>("Sprite/"+ eventName);
        thisImg = imageObject.GetComponent<Image>();
        thisImg.sprite = sprite;

        StartCoroutine("imageActive");
    }
    IEnumerator imageActive()
    {
        yield return new WaitForSeconds(1f);
        imageObject.SetActive(true);
        thisImg.DOFade(1.0f, 1f);
    }
}
