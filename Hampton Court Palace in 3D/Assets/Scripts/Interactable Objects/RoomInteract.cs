using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoomInteract : Interactable
{

    [SerializeField] public string JSONRoomSlug;             // this must be identical to the objectSlug in JSON file.
    public Room objectRoom;

    private void Start()
    {
        interactUI.SetActive(false);
        focusUI.SetActive(false);
        objectRoom = ItemDatabase.Instance.GetRoom(JSONRoomSlug);
    }

    public override void OnFocus()
    {
        base.OnFocus();
        if (canBeInteractedWith && !isCurrentlyInteracted)
        {
            focusUI.transform.GetChild(0).GetComponent<TMP_Text>().text = "Room of interest: " + objectRoom.RoomName + " - Click to add to room database.";
            interactUI.transform.GetChild(0).GetComponent<TMP_Text>().text = objectRoom.addedToDatabaseString;
        }
        else
        {
            focusUI.SetActive(false);
        }
    }

    public override void OnInteract()
    {
        base.OnInteract();

        if (canBeInteractedWith)
        {
            CheckRoomInteract();
            isCurrentlyInteracted = true;
            //InventoryController.Instance.GiveItem(objectItem);
        }
    }

    public override void OnLoseFocus()
    {
        base.OnLoseFocus();
        isCurrentlyInteracted = false;
    }

    public void CheckRoomInteract()
    {
        if (!DatabaseController.Instance.databaseRooms.Contains(objectRoom))
        {
            DatabaseController.Instance.GiveRoom(objectRoom);
            interactUI.transform.GetChild(0).GetComponent<TMP_Text>().text = objectRoom.RoomName + " has been added to the room database. Press I to learn more.";
            interactUI.SetActive(true);
            //DialogueManager.Instance.AddNewDialogue(dialogue, characterName, portrait);
            Debug.Log("Got to part 1");
        }
        else
        {
            //DialogueManager.Instance.AddNewDialogue(spokenToDialogue, characterName, portrait);
            interactUI.transform.GetChild(0).GetComponent<TMP_Text>().text = objectRoom.RoomName + " has already been added to the room database.";
            interactUI.SetActive(true);
            Debug.Log("Got to part 2");
        }
    }
}

