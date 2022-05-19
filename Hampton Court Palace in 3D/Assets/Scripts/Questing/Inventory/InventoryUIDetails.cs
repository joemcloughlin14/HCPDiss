using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUIDetails : MonoBehaviour
{
    Item item;
    Button selectedItemButton;
    TextMeshProUGUI itemNameText, itemDescriptionText;
    public InventoryUIDetails inventoryDetailsPanel; // Check where this needs to be used.

    private void Start()
    {
        var itemNameChild = inventoryDetailsPanel.transform.Find("Inventory_Details").transform.Find("Item_Name");
        itemNameText = itemNameChild.GetComponent<TextMeshProUGUI>();
        var itemDescriptionChild = inventoryDetailsPanel.transform.Find("Inventory_Details").transform.Find("Item_Description");
        itemDescriptionText = itemDescriptionChild.GetComponent<TextMeshProUGUI>();
    }

    public void SetItem(Item item, Button selectedButton)
    {
        this.item = item;
        selectedItemButton = selectedButton;
        itemNameText.text = item.ItemName;
        itemDescriptionText.text = item.Description;
    }
}
