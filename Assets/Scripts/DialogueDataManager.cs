using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDataManager : MonoBehaviour
{
    public static  DialogueDataManager Instance;
    [SerializeField] string csv_FileName;
    [SerializeField] string eventName;

    Dictionary<int, Dialogue> dialogueDic = new Dictionary<int, Dialogue>();    
    public static bool isFinished = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DialogueParser theParser  = GetComponent<DialogueParser>();
            Dialogue[] dialogues = theParser.Parse(csv_FileName,eventName);
            for(int i = 0; i < dialogues.Length; i++)
            {
                dialogueDic.Add(i + 1, dialogues[i]);
            }
            isFinished = true;
            Debug.Log(dialogues[1].contexts);
        } 
    }
}
