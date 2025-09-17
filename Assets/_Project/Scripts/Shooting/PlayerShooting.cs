using UnityEngine;
using Zenject;

public class PlayerShooting : MonoBehaviour
{
    private Joystick _joystick;
    private IGun _currentGun;

    [Inject]
    public void Construct(PlayerInputContainer inputContainer)
    {
        _joystick = inputContainer.ShootingJoystick;
    }

    private void Update()
    {
        if (_currentGun == null)
            return;

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

        if (newGun == null)
        {
            _currentGun = null;
            return;
        }

        _currentGun = Instantiate(newGun, transform.position, Quaternion.identity, transform);
    }
}
