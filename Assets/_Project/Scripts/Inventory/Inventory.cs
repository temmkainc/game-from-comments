using Comments.Level;
using System;

public class Inventory : IDisposable
{
    public int SlotCount { get; private set; } = 6;

    private readonly InventorySlot[] _slots;
    private int _activeSlot = 0;

    private readonly Player _player;

    public Inventory(Player player, PlayerInputContainer _inputContainer)
    {
        _player = player;

        _slots = new InventorySlot[SlotCount];
        for (int i = 0; i < _slots.Length; i++)
        {
            _slots[i] = UnityEngine.Object.Instantiate(_inputContainer.InventorySlotPrefab, _inputContainer.InventorySlotsParent);
            _slots[i].Setup(i);
            _slots[i].OnSelectClicked += SelectSlot;
        }
        _activeSlot = 0;
    }

    public void AddItem(Item item)
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            if (_slots[i].IsEmpty)
            {
                _slots[i].UpdateInfo(item);
                break;
            }
        }
    }

    public void RemoveItem(Item item)
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            if (_slots[i].Item == item)
            {
                _slots[i].UpdateInfo(null);
                ClearPreviousItem();
                break;
            }
        }
    }

    public void SelectSlot(int slotIndex, Item item)
    {
        _slots[_activeSlot].SetHighlightActive(false);
        _activeSlot = slotIndex;
        _slots[_activeSlot].SetHighlightActive(true);


        ClearPreviousItem();
        if (item == null)
            return;
        item.Equip(_player);
    }

    private void ClearPreviousItem()
    {
        _player.UI.DisableAdditionalUI();
        _player.Shooting.EquipGun(null);
    }

    public void Dispose()
    {
        foreach (var slot in _slots)
        {
            if (slot == null)
                continue;

            slot.OnSelectClicked -= SelectSlot;
        }
    }
}
