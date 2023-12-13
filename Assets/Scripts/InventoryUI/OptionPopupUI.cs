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
        var equipButton = _equipButton.GetComponent<Button>();
        var removeButton = _removeButton.GetComponent<Button>();

        removeButton.onClick.AddListener(RemoveItemFromSlot);
        equipButton.onClick.AddListener(EquipItemFromSlot);
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


    private void EquipItemFromSlot()
    {
        var data = _inventory.GetItemData(Index);
        Debug.Log(data.name);
        Hide();
    }
    public void RemoveItemFromSlot()
    {
        _inventory.Remove(Index);
        Hide();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        inContext = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        inContext = false;
    }
}
