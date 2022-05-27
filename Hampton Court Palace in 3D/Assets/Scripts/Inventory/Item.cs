using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Item
{
    public enum ItemTypes { Weapon, Consumable, Quest, Character }             // Would need to add itemtype here for non important.
    public string ObjectSlug { get; set; }
    public string InitialDescription { get; set; }
    public string Description { get; set; }
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public ItemTypes ItemType { get; set; }
    public string ActionName { get; set; }
    public string ItemName { get; set; }

    public Item(string _ObjectSlug)
    {
        this.ObjectSlug = _ObjectSlug;
    }

    [Newtonsoft.Json.JsonConstructor]
    public Item(string _ObjectSlug, string _Description, string _InitialDescription, ItemTypes _ItemType, string _ActionName, string _ItemName)
    {
        this.ObjectSlug = _ObjectSlug;
        this.Description = _Description;
        this.InitialDescription = _InitialDescription;
        this.ItemType = _ItemType;
        this.ActionName = _ActionName;
        this.ItemName = _ItemName;
    }
}

