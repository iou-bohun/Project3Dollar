using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class GetDialogue : MonoBehaviour
{
    SceneManager sceneManager;
    [SerializeField] TextMeshProUGUI text;
    List<string> contextList = new List<string>();
    public void GetDialogue_(string _EventName)
    {
        TextAsset csvData = Resources.Load<TextAsset>("Events");
        string[] data = csvData.text.Split(new char[] { '\n' }); // ø£≈Õ ±‚¡ÿ¿∏∑Œ ¬…∞∑
        for(int i=1; i<data.Length;)
        {
            string[] row = data[i].Split(new char[] { ',' });
            Dialogue dialogue = new Dialogue();
            if (row[0].ToString() != _EventName)
            {
                i++;
            }
            else
            {  
                do
                {
                    contextList.Add(row[1]);
                    if (++i < data.Length)
                    {
                        row = data[i].Split(new char[] { ',' });
                    }
                    else
                        break;
                } while (row[0].ToString() == "");
            }
        }
    }

    private void Start()
    {
        GetDialogue_(FindAnyObjectByType<SceneManager>().eventName);
        StartCoroutine("Typing");
    }

    IEnumerator Typing()
    {
        text.text = contextList[0];
        TMPText(text, 1f);

        yield return new WaitForSeconds(1.5f);
        
    }

    public void TMPText(TextMeshProUGUI text, float duration)
    {
        text.maxVisibleCharacters = 0;
        DOTween.To(x=> text.maxVisibleCharacters = (int)x,0f,text.text.Length,duration);
    }
}
