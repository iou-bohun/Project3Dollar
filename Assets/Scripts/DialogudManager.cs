using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogudManager : MonoBehaviour
{
    public static DialogudManager instance;
    public Dialogue theDialogue;
    public Dialogue TheDialogue { get { return theDialogue; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            ParseDialogue theParse = GetComponent<ParseDialogue>();
            theDialogue = theParse.Parse(FindAnyObjectByType<SceneManager>().eventName);
        }
    }
}
