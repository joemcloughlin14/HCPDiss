using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUIItem : MonoBehaviour
{
    public Item item;

    public void SetItem(Item item)
    {
        this.item = item;
        SetUpItemValues();
    }

    void SetUpItemValues()
    {
        this.transform.Find("Item_Name").GetComponent<TextMeshProUGUI>().text = item.ItemName;
    }

    public void OnSelectItemButton()
    {
        Debug.Log("It worked!");
        InventoryController.Instance.SetItemDetails(item, GetComponent<Button>());  // currently gives null pointer.
    }
    
}