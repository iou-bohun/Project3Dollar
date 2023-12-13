using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionPopupUI : MonoBehaviour
{
    [SerializeField]
    private Button equipButton;
    [SerializeField]
    private Button removeButton;

    public int Index { get; private set; }

    private RectTransform _rectTransform;

    private void Awake()
    {
        TryGetComponent(out _rectTransform);
        Hide();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPopupUIRect(Transform slotRect)
    {
        _rectTransform.position = slotRect.position + new Vector3(_rectTransform.rect.width / 2, -(_rectTransform.rect.height) / 2);
    }

    public void SetIndex(int index) => Index = index; 

    public void Show() => gameObject.SetActive(true);

    public void Hide() => gameObject.SetActive(false);
}
