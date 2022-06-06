using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DatabaseUIItemDetails : MonoBehaviour
{
    Item item;                      // no value?
    Button selectedItemButton;      // no value?
    TextMeshProUGUI itemNameText, itemDescriptionText;

    private void Start()
    {
        itemNameText = transform.Find("Item_Name").GetComponent<TextMeshProUGUI>();
        itemDescriptionText = transform.Find("Item_Description").GetComponent<TextMeshProUGUI>();
        RemoveItem();
    }

    public void SetItem(Item item, Button selectedButton)
    {
        gameObject.SetActive(true);
        this.item = item;
        selectedItemButton = selectedButton;
        itemNameText.text = item.ItemName;
        itemDescriptionText.text = item.Description;
    }
    public void RemoveItem()
    {
        gameObject.SetActive(false);
    }
}
