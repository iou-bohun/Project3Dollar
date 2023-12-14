using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class Splash : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI startTxt;

    private void Start()
    {
        startTxt.DOFade(1.0f, 2f).SetLoops(-1, LoopType.Yoyo);
    }
}
