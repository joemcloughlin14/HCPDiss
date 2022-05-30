using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance { get; set; }
    public InventoryUIDetails inventoryDetailsPanel;
    public List<Item> playerItems = new List<Item>();

    private void Start()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void GiveItem(string itemSlug)
    {
        Item item = ItemDatabase.Instance.GetItem(itemSlug);
        if (!playerItems.Contains(item))
        {
            playerItems.Add(item);
            Debug.Log(playerItems.Count + " items in inventory. Added: " + itemSlug);
            UIEventHandler.ItemAddedToInventory(item);
        }
    }

    public void GiveItem(Item item)
    {
        if (!playerItems.Contains(item))
        {
            playerItems.Add(item);
            UIEventHandler.ItemAddedToInventory(item);
        }
    }

    public void SetItemDetails(Item item, Button selectedButton)
    {
        inventoryDetailsPanel.SetItem(item, selectedButton);
    }
}
