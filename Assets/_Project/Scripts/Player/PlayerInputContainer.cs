using Comments.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInputContainer : MonoBehaviour
{
    [Header("Movement")]
    [field: SerializeField] public Joystick Joystick { get; private set; }
    [field: SerializeField] public Joystick ShootingJoystick { get; private set; }
    [field: SerializeField] public Button JumpButton { get; private set; }
    [field: SerializeField] public Button SizeButton { get; private set; }
    [Header("Resizer")]
    [field: SerializeField] public Sprite UpSizeSprite { get; private set; }
    [field: SerializeField] public Sprite DownSizeSprite { get; private set; }
    [Header("Action")]
    [field: SerializeField] public Button ActionButton { get; private set; }
    [Header("UI")]
    [field: SerializeField] public SmoothBar HealthBar { get; private set; }
    [Header("Inventory")]
    [field: SerializeField] public InventorySlot InventorySlotPrefab { get; private set; }
    [field: SerializeField] public Transform InventorySlotsParent { get; private set; }
    [field: SerializeField] public List<Item> InitialItems { get; private set; }
}