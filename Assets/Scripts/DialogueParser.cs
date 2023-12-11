using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{
    public Dialogue[] Parse(string _CSVFileName, string _EventName)
    {
        List<Dialogue> dialogueList = new List<Dialogue>(); 
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName);

        string[] data = csvData.text.Split(new char[] { '\n' }); // ø£≈Õ ±‚¡ÿ¿∏∑Œ ¬…∞∑

        for(int i=1; i<data.Length;)
        {
            string[] row = data[i].Split(new char[] { ',' });
            if (row[0].ToString()!= _EventName)
            {
                i++;
            }
            else
            {
                Dialogue dialogue = new Dialogue();
                dialogue.name = row[0];
                List<string> contextList = new List<string>();
                do
                {
                    contextList.Add(row[1]);
                    Debug.Log(row[1]);
                    if (++i < data.Length)
                    {
                        row = data[i].Split(new char[] { ',' });
                    }
                    else
                        break;
                } while (row[0].ToString() == "");
            }
        }
        return dialogueList.ToArray();
    }

    private void Start()
    {
        Parse("Events", "FindWeagon");
    }
}
