using UnityEngine;
public class CollectableItem : MonoBehaviour
{
    public InventoryItem itemData; 
    private InventoryManager inventoryManager; 
private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject player = other.gameObject;

            if (player.GetComponent<InventoryManager>() != null)
            {
                inventoryManager = player.GetComponent<InventoryManager>(); 
            if (inventoryManager.CanAddItem())
                {
                    Collect(); 
                }
                else
                {
                    Debug.Log("Cannot collect item, inventory is full");
                }
            }
        }
    }
    public void Collect()
    {
        inventoryManager.AddItem(itemData);
        Collected();
    }
    private void Collected()
    {
        Destroy(gameObject);
    }
}