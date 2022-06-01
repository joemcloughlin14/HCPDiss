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
}



// May not have to create whole new JSON file. Must be a way to find items based on their type, i.e character. Then if it is a character, save it in this other database etc.
