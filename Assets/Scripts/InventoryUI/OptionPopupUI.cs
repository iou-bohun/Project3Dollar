using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OptionPopupUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Button _equipButton;
    [SerializeField]
    private Button _removeButton;
    [SerializeField]
    private Button _unequipButton;
    [SerializeField]
    private Inventory _inventory;

    public int Index { get; private set; }

    private RectTransform _rectTransform;

    bool inContext;

    GameObject myGO;

    private void Awake()
    {
        TryGetComponent(out _rectTransform);
        Hide();
        myGO = gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !inContext)
        {
            myGO.SetActive(inContext);
        }
    }

    public void SetPopupUIRect(Transform slotRect)
    {
        _rectTransform.position = slotRect.position + new Vector3(_rectTransform.rect.width / 2, -(_rectTransform.rect.height) / 2);
    }

    public void SetIndex(int index) => Index = index; 

    public void Show() => gameObject.SetActive(true);

    public void Hide() => gameObject.SetActive(false);


    public void OnPointerEnter(PointerEventData eventData)
    {
        inContext = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        inContext = false;
    }

    public void DisableEquipButton()
    {
        _equipButton.interactable = false;
        _unequipButton.interactable = true;
    }

    public void DisableUnEquipButton()
    {
        _unequipButton.interactable= false;
        _equipButton.interactable = true;
    }
}
