using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class DatabaseController : MonoBehaviour
{
    public static DatabaseController Instance { get; set; }
    public DatabaseUIItemDetails databaseItemDetailsPanel;
    public DatabaseUICharacterDetails databaseCharacterDetailsPanel;
    public DatabaseUIRoomDetails databaseRoomDetailsPanel;
    public List<Item> databaseItems = new List<Item>();
    public List<Character> databaseCharacters = new List<Character>();
    public List<Room> databaseRooms = new List<Room>();
    //public List<Quests> currentQuests = new List<Quests>();

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
            UIEventHandler.ItemAddedToDatabase(item);
        }
    }

    public void GiveItem(Item item)
    {
        if (!databaseItems.Contains(item))
        {
            databaseItems.Add(item);
            UIEventHandler.ItemAddedToDatabase(item);
        }
    }

    public void SetItemDetails(Item item, Button selectedButton)
    {
        databaseItemDetailsPanel.SetItem(item, selectedButton);
    }

    public void GiveCharacter(string characterSlug)
    {
        Character character = ItemDatabase.Instance.GetCharacter(characterSlug);
        if (!databaseCharacters.Contains(character))
        {
            databaseCharacters.Add(character);
            UIEventHandler.CharacterAddedToDatabase(character);
        }
    }

    public void GiveCharacter(Character character)
    {
        if (!databaseCharacters.Contains(character))
        {
            databaseCharacters.Add(character);
            UIEventHandler.CharacterAddedToDatabase(character);
        }
    }

    public void SetCharacterDetails(Character character, Button selectedButton)
    {
        databaseCharacterDetailsPanel.SetCharacter(character, selectedButton);
    }

    public void GiveRoom(string roomSlug)
    {
        Room room = ItemDatabase.Instance.GetRoom(roomSlug);
        if (!databaseRooms.Contains(room))
        {
            databaseRooms.Add(room);
            UIEventHandler.RoomAddedToDatabase(room);
        }
    }

    public void GiveRoom(Room room)
    {
        if (!databaseRooms.Contains(room))
        {
            databaseRooms.Add(room);
            UIEventHandler.RoomAddedToDatabase(room);
        }
    }

    public void SetRoomDetails(Room room, Button selectedButton)
    {
        databaseRoomDetailsPanel.SetRoom(room, selectedButton);
    }
}

// the addition of room database is not complete. Began changing this script and partially updating inventory script names to database, including DatabaseUIItemDetails
// Consider whether this will be used the same as rooms may be added by non interaction? Perhaps triggers. Although maybe doors? or the floors?
