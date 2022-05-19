using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance { get; set; }
    //public ConsumableController consumableController;
    public InventoryUIDetails inventoryDetailsPanel;
    public List<Item> playerItems = new List<Item>();

    private void Start()
    {
        Debug.Log("Hello");
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        //consumableController = GetComponent<ConsumableController>();
        //GiveItem("sword");
        GiveItem("potion_log");
    }

    public void GiveItem(string itemSlug)
    {
        Debug.Log("Got to this point (GiveItem).");
        Item item = ItemDatabase.Instance.GetItem(itemSlug);
        playerItems.Add(item);
        Debug.Log(playerItems.Count + " items in inventory. Added: " + itemSlug);
        UIEventHandler.ItemAddedToInventory(item);
    }

    public void SetItemDetails(Item item, Button selectedButton)
    {
        inventoryDetailsPanel.SetItem(item, selectedButton);
    }

    //public void ConsumeItem(Item itemToConsume)
    //{
    //    consumableController.ConsumeItem(itemToConsume);
    //}
}
