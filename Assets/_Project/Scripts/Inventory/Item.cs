using Comments.Level;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Consumable
}

public abstract class Item : ScriptableObject
{
    [field: SerializeField] public string Name { get; protected set; }
    [field: SerializeField] public ItemType Type { get; protected set; }
    [field: SerializeField] public Sprite Icon { get; protected set; }

    public abstract void Equip(Player player);
}
