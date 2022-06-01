using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventHandler : MonoBehaviour
{
    public delegate void ItemEventHandler(Item item);
    public static event ItemEventHandler OnItemAddedToInventory;
    public delegate void CharacterEventHandler(Character character);
    public static event CharacterEventHandler OnCharacterAddedToInventory;

    public static void ItemAddedToInventory(Item item)
    {
        OnItemAddedToInventory(item);
    }

    public static void CharacterAddedToInventory(Character character)
    {
        OnCharacterAddedToInventory(character);
    }
}