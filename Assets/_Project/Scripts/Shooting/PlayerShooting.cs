using UnityEngine;
using Zenject;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GunBase _startingGun;

    private Joystick _joystick;
    private IGun _currentGun;

    [Inject]
    public void Construct(PlayerInputContainer inputContainer)
    {
        _joystick = inputContainer.ShootingJoystick;
    }

    private void Start()
    {
        EquipGun(_startingGun);
    }

    private void Update()
    {
        Vector2 input = new Vector2(_joystick.Horizontal, _joystick.Vertical);

        if (input.sqrMagnitude > 0.1f)
        {
            Vector2 aimDir = input.normalized;
            _currentGun?.Shoot(aimDir);

            if (_currentGun is GunBase gunObj)
            {
                gunObj.transform.up = aimDir;
            }
        }
    }

    public void EquipGun(GunBase newGun)
    {
        if (_currentGun is GunBase oldGun)
        {
            Destroy(oldGun.gameObject);
        }

        _currentGun = Instantiate(newGun, transform.position, Quaternion.identity, transform);
    }
}
