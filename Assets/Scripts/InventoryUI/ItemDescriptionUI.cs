using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemDescriptionUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text descriptionText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDescriptiponText(string description)
    {
        descriptionText.text = description;
    }
}
