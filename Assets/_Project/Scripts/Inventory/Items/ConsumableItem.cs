using Comments.Level;
using UnityEngine;

public enum ConsumableType
{
    Heal
}

[CreateAssetMenu(menuName = "Items/Consumable")]
public class ConsumableItem : Item
{
    [field: SerializeField] public ConsumableType Subtype { get; private set; }
    [field: SerializeField] public int Value { get; private set; }

    public override void Equip(Player player)
    {
        player.UI.SetActionButtonActive(true);

        switch (Subtype)
        {
            case ConsumableType.Heal:
                player.UI.ChangeActionButtonListener(() => HealAction(player));
                break;
            default:
                break;
        }
    }

    private void HealAction(Player player)
    {
        player.Health.ChangeHealth(Value);
        player.Inventory.RemoveItem(this);
    }
}