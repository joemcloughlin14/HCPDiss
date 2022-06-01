using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance { get; set; }
    public InventoryUIDetails inventoryDetailsPanel;
    public InventoryUIDetailsCh inventoryDetailsChPanel;
    public List<Item> databaseItems = new List<Item>();
    public List<Character> databaseCharacters = new List<Character>();
    public List<Quests> currentQuests = new List<Quests>();

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
        if (!databaseItems.Contains(item))
        {
            databaseItems.Add(item);
            Debug.Log(databaseItems.Count + " items in inventory. Added: " + itemSlug);
            UIEventHandler.ItemAddedToInventory(item);
        }
    }

    public void GiveItem(Item item)
    {
        if (!databaseItems.Contains(item))
        {
            databaseItems.Add(item);
            UIEventHandler.ItemAddedToInventory(item);
        }
    }

    public void SetItemDetails(Item item, Button selectedButton)
    {
        inventoryDetailsPanel.SetItem(item, selectedButton);
    }

    public void GiveCharacter(string characterSlug)
    {
        Character character = ItemDatabase.Instance.GetCharacter(characterSlug);
        if (!databaseCharacters.Contains(character))
        {
            databaseCharacters.Add(character);
            Debug.Log(databaseCharacters.Count + " characters in database. Added: " + characterSlug);
            UIEventHandler.CharacterAddedToInventory(character);
        }
    }

    public void GiveCharacter(Character character)
    {
        if (!databaseCharacters.Contains(character))
        {
            databaseCharacters.Add(character);
            UIEventHandler.CharacterAddedToInventory(character);
        }
    }

    public void SetCharacterDetails(Character character, Button selectButton)
    {
        inventoryDetailsChPanel.SetCharacter(character, selectButton);
    }
}
