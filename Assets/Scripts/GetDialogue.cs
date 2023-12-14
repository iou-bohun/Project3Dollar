using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class GetDialogue : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI firstText;
    List<string> contextList = new List<string>();
    Dialogue dialogue = new Dialogue();
    public Dialogue GetDialogue_(string _EventName)
    {
        TextAsset csvData = Resources.Load<TextAsset>("Events");
        string[] data = csvData.text.Split(new char[] { '\n' }); // ø£≈Õ ±‚¡ÿ¿∏∑Œ ¬…∞∑
        for(int i=1; i<data.Length;)
        {
            string[] row = data[i].Split(new char[] { ',' });
           
            if (row[0].ToString() != _EventName)
            {
                i++;
            }
            else
            {  
                do
                {
                    contextList.Add(row[2]);
                    if (++i < data.Length)
                    {
                        row = data[i].Split(new char[] { ',' });
                    }
                    else
                        break;
                } while (row[0].ToString() == "");
                dialogue.contexts = contextList.ToArray();
            }
        }
        return dialogue;
    }

    private void Start()
    {
        GetDialogue_(FindAnyObjectByType<SceneManager>().eventName);
        StartCoroutine("Typing");
    }

    IEnumerator Typing()
    {
        firstText.text = contextList[0];
        TMPText(firstText, 1.5f);
        
        yield return new WaitForSeconds(1.5f);
        
    }

    public void TMPText(TextMeshProUGUI text, float duration)
    {
        text.maxVisibleCharacters = 0;
        DOTween.To(x=> text.maxVisibleCharacters = (int)x,0f,text.text.Length,duration);
    }

}
