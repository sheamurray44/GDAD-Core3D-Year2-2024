using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryDisplay : MonoBehaviour
{
    public GameObject slotPrefab;
    public Transform slotParent;
    public float xSpacing = 128f;
    public float ySpacing = 128f;

    private List<GameObject> slots = new List<GameObject>();

    private void OnEnable()
    {
        InventoryManager.OnInventoryChanged += UpdateInventoryUI;
    }

    private void OnDisable()
    {
        InventoryManager.OnInventoryChanged -= UpdateInventoryUI;
    }

    private void UpdateInventoryUI(List<InventoryItem> items)
    {
        foreach (GameObject slot in slots)
        {
            Destroy(slot);
        }
        slots.Clear();

        for (int i = 0; i < items.Count; i++)
        {
            InventoryItem item = items[i];
            GameObject newSlot = Instantiate(slotPrefab, slotParent);

            int row = i / 2;
            int column = i % 2;

            newSlot.transform.localPosition = new Vector3(column * xSpacing, -row * ySpacing, 0);
            slots.Add(newSlot);

            Image icon = newSlot.transform.Find("Icon").GetComponent<Image>();
            TextMeshProUGUI nameText = newSlot.transform.Find("NameText").GetComponent<TextMeshProUGUI>();

            icon.sprite = item.icon;
            nameText.text = item.itemName;
        }
    }
}
