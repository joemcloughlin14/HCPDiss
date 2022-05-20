using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUIDetails : MonoBehaviour
{
    Item item;                      // no value?
    Button selectedItemButton;      // no value?
    TextMeshProUGUI itemNameText, itemDescriptionText;
    //public InventoryUIDetails inventoryDetailsPanel;

    private void Start()
    {
        Debug.Log("inventory UI details");
        itemNameText = transform.Find("Item_Name").GetComponent<TextMeshProUGUI>();
        itemDescriptionText = transform.Find("Item_Description").GetComponent<TextMeshProUGUI>();
        Debug.Log("Found " + itemDescriptionText);
    }

    public void SetItem(Item item, Button selectedButton)
    {
        Debug.Log("Got to SetItem");
        Debug.Log("found: " + itemNameText);
        this.item = item;
        selectedItemButton = selectedButton;
        itemNameText.text = item.ItemName;
        itemDescriptionText.text = item.Description;
        
    }
}
