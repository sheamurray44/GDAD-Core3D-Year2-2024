using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponItem", menuName = "Inventory/Weapon Item")]
public class WeaponItem : InventoryItem
{
    public int damage;
    public int ammoCount;

    private void OnEnable()
    {
        itemType = ItemType.Weapon;
    }
}
