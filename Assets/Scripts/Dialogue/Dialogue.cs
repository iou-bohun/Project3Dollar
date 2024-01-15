using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [Tooltip("��� ġ�� ĳ���� �̸�")]
    public string eventName;
    [Tooltip("��� ����")]
    public string[] contexts;
    [Tooltip("��ư")]
    public string[] buttons;
    [Tooltip("��ư ��")]
    public int buttonCount;
}
