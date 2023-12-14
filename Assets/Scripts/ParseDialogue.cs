using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParseDialogue : MonoBehaviour
{
    Dialogue dialogue = new Dialogue();
    public Dialogue Parse(string _EventName)
    {
        TextAsset csvData = Resources.Load<TextAsset>("Events");
        string[] data = csvData.text.Split(new char[] { '\n' }); // ø£≈Õ ±‚¡ÿ¿∏∑Œ ¬…∞∑
        for (int i = 1; i < data.Length;)
        {
            string[] row = data[i].Split(new char[] { ',' });
            
            if (row[0].ToString() != _EventName)
            {
                i++;
            }
            else
            {
                dialogue.eventName = row[0];
                List<string> contextList = new List<string>();
                List<string> buttonList = new List<string>();
                int buttonCount = 0;
                do
                {
                    contextList.Add(row[2]);
                    buttonList.Add(row[1]);
                    buttonCount++;
                    if (++i < data.Length)
                    {
                        row = data[i].Split(new char[] { ',' });
                    }
                    else
                        break;
                } while (row[0].ToString() == "");
                dialogue.contexts = contextList.ToArray();
                dialogue.buttons = buttonList.ToArray();    
                dialogue.buttonCount = buttonCount;
            }
        }
        return dialogue;
    }
}
