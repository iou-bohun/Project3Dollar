using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    [SerializeField]
    private Image _iconImage;

    private Transform _iconRect;
    private GameObject _iconGameObject;

    public int Index { get; private set; }
    public bool HasItem => _iconImage.sprite != null;


    private void Awake()
    {
        _iconImage.raycastTarget = false;

        _iconRect = _iconImage.transform;
        _iconGameObject = _iconImage.gameObject;

        HideIcon();
    }

    private void ShowIcon() => _iconGameObject.SetActive(true);
    private void HideIcon() => _iconGameObject.SetActive(false);


    public void SetSlotIndex(int index) => Index = index;

    public void SetItem(Sprite itemSprite)
    {
        //if (!this.IsAccessible) return;

        if (itemSprite != null)
        {
            _iconImage.sprite = itemSprite;
            ShowIcon();
        }
        else
        {
            RemoveItem();
        }
    }

    /// <summary> 슬롯에서 아이템 제거 </summary>
    public void RemoveItem()
    {
        _iconImage.sprite = null;
        HideIcon();
    }

}
