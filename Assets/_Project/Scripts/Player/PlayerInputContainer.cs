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
    [Header("UI")]
    [field: SerializeField] public Image HealthBar { get; private set; }
}