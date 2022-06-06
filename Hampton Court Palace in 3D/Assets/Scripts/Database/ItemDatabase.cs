using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase Instance { get; set; }
    private List<Item> Items { get; set; }
    private List<Character> Characters { get; set; }
    private List<Room> Rooms { get; set; }
   
    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
        BuildDatabase();
    }

    private void BuildDatabase()
    {
        Items = JsonConvert.DeserializeObject<List<Item>>(Resources.Load<TextAsset>("JSON/Items").ToString());
        Characters = JsonConvert.DeserializeObject<List<Character>>(Resources.Load<TextAsset>("JSON/Characters").ToString());
        Rooms = JsonConvert.DeserializeObject<List<Room>>(Resources.Load<TextAsset>("JSON/Rooms").ToString());
    }

    public Item GetItem(string itemSlug)
    {
        foreach (Item item in Items)
        {
            if (item.ObjectSlug == itemSlug)
                return item;
            //Debug.Log("Found item: " + itemSlug);
        }
        Debug.LogWarning("Couldn't find item: " + itemSlug);
        return null;
    }

    public Character GetCharacter(string characterSlug)
    {
        foreach (Character character in Characters)
        {
            if (character.CharacterSlug == characterSlug)
                return character;
            //Debug.Log("Found character: " + characterSlug);
        }
        Debug.LogWarning("Couldn't find character: " + characterSlug);
        return null;
    }

    public Room GetRoom(string roomSlug)
    {
        foreach (Room room in Rooms)
        {
            if (room.RoomSlug == roomSlug)
                return room;
            Debug.Log("Found room: " + roomSlug);
        }
        Debug.LogWarning("Couldn't find room: " + roomSlug);
        return null;
    }
}