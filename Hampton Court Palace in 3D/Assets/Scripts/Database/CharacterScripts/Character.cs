using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Character
{
    public enum CharacterTypes { NPC, QuestGivingNPC }
    public string CharacterSlug { get; set; }
    public string CharacterName { get; set; }
    public string addedToDatabaseString { get; set; }
    public string Description { get; set; }
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public CharacterTypes CharacterType { get; set; }


    public Character(string _CharacterSlug)
    {
        this.CharacterSlug = _CharacterSlug;
    }

    [Newtonsoft.Json.JsonConstructor]
    public Character(string _CharacterSlug, string _Description, string _AddedToDatabaseString, CharacterTypes _CharacterType, string _CharacterName)
    {
        this.CharacterSlug = _CharacterSlug;
        this.Description = _Description;
        this.addedToDatabaseString = _AddedToDatabaseString;
        this.CharacterType = _CharacterType;
        this.CharacterName = _CharacterName;
    }
}
