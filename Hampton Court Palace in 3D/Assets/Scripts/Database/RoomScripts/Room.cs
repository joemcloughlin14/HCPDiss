using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Room
{
    public enum RoomTypes { DatabaseRoom, QuestRoom }
    public string RoomSlug { get; set; }
    public string RoomName { get; set; }
    public string addedToDatabaseString { get; set; }
    public string Description { get; set; }
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public RoomTypes RoomType { get; set; }


    public Room(string _RoomSlug)
    {
        this.RoomSlug = _RoomSlug;
    }

    [Newtonsoft.Json.JsonConstructor]
    public Room(string _RoomSlug, string _Description, string _AddedToDatabaseString, RoomTypes _RoomType, string _RoomName)
    {
        this.RoomSlug = _RoomSlug;
        this.Description = _Description;
        this.addedToDatabaseString = _AddedToDatabaseString;
        this.RoomType = _RoomType;
        this.RoomName = _RoomName;
    }
}
