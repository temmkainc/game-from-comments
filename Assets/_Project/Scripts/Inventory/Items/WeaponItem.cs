using Comments.Level;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Weapon")]
public class WeaponItem : Item
{
    [field: SerializeField] public GunBase Weapon;

    public override void Equip(Player player)
    {
        player.UI.SetShootingJoystickActive(true);
        player.Shooting.EquipGun(Weapon);
    }
}