using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventHandler : MonoBehaviour
{
    public delegate void ItemEventHandler(Item item);
    public static event ItemEventHandler OnItemAddedToDatabase;
    public delegate void CharacterEventHandler(Character character);
    public static event CharacterEventHandler OnCharacterAddedToDatabase;
    public delegate void RoomEventHandler(Room room);
    public static event RoomEventHandler OnRoomAddedToDatabase;

    public static void ItemAddedToDatabase(Item item)
    {
        OnItemAddedToDatabase(item);
    }

    public static void CharacterAddedToDatabase(Character character)
    {
        OnCharacterAddedToDatabase(character);
    }

    public static void RoomAddedToDatabase(Room room)
    {
        OnRoomAddedToDatabase(room);
    }
}