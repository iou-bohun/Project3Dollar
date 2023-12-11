using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetDialogue : MonoBehaviour
{
    [SerializeField] string eventName;
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
        GetDialogue_(eventName);
        text.text = contextList[0];
    }
}
