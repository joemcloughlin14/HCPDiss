using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Item
{
    public enum ItemTypes { QuestItem, DatabaseItem, DoorKey, DoorLock }             
    public string ObjectSlug { get; set; }
    public string ItemName { get; set; }
    public string addedToDatabaseString { get; set; }
    public string Description { get; set; }
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public ItemTypes ItemType { get; set; }
    

    public Item(string _ObjectSlug)
    {
        this.ObjectSlug = _ObjectSlug;
    }

    [Newtonsoft.Json.JsonConstructor]
    public Item(string _ObjectSlug, string _Description, string _AddedToDatabaseString, ItemTypes _ItemType, string _ItemName)
    {
        this.ObjectSlug = _ObjectSlug;
        this.Description = _Description;
        this.addedToDatabaseString = _AddedToDatabaseString;
        this.ItemType = _ItemType;
        this.ItemName = _ItemName;
    }
}

