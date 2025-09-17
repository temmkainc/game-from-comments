using System;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [field: SerializeField] public Image IconImage { get; private set; }
    [field: SerializeField] public Image HighlightImage { get; private set; }
    [field: SerializeField] public Button EquipButton { get; private set; }
    [field: SerializeField] public Item Item { get; private set; }

    public bool IsEmpty => Item == null;

    private int _index;

    public event Action<int, Item> OnSelectClicked;

    private void OnDestroy()
    {
        EquipButton.onClick.RemoveAllListeners();
    }

    public void Setup(int index)
    {
        _index = index;
        SetHighlightActive(false);
        UpdateInfo(null);
    }

    public void SetHighlightActive(bool value)
    {
        HighlightImage.gameObject.SetActive(value);
    }

    public void UpdateInfo(Item newItem)
    {
        EquipButton.onClick.RemoveAllListeners();
        EquipButton.onClick.AddListener(Select);

        if (newItem == null)
        {
            Item = null;
            IconImage.sprite = null;
            return;
        }

        Item = newItem;
        IconImage.sprite = Item.Icon;
    }

    private void Select()
    {
        OnSelectClicked?.Invoke(_index, Item);
    }
}
