using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [Tooltip("대사 치는 캐릭터 이름")]
    public string eventName;
    [Tooltip("대사 내용")]
    public string[] contexts;
    [Tooltip("버튼")]
    public string[] buttons;
    [Tooltip("버튼 수")]
    public int buttonCount;
}
