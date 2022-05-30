using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NonQuestNPC : NPC
{
    bool hasSpokenTo;
    public string[] spokenToDialogue;
    private Item objectItem;
    private bool canBeInteractedWith = true;
    //private bool isSpeakingTo = false;
    [SerializeField] private string JSONObjectSlug;         // this must be identical to the objectSlug in JSON file.
   


    private void Start()
    {
        hasSpokenTo = false;
        focusUI.SetActive(false);
        interactUI.SetActive(false);
        objectItem = ItemDatabase.Instance.GetItem(JSONObjectSlug);
    }

    public override void OnInteract()
    {
        CheckInteract();
        base.OnInteract();
        focusUI.SetActive(false);
    }

    public override void OnFocus()
    {
        base.OnFocus();
        if (canBeInteractedWith && !isSpeakingTo)
        {
            
            focusUI.transform.GetChild(0).GetComponent<TMP_Text>().text = "Speak to " + objectItem.ItemName + ".";
        }
        else
        {
            focusUI.SetActive(false);
        }
    }

    public override void OnLoseFocus()
    {
        base.OnLoseFocus();
        //interactUI.SetActive(false);
        isSpeakingTo = false;
    }

    private void CheckInteract()
    {
        if (!InventoryController.Instance.playerItems.Contains(objectItem))
        {
            InventoryController.Instance.GiveItem(objectItem);
            interactUI.transform.GetChild(0).GetComponent<TMP_Text>().text = objectItem.ItemName + " has been added to the database. Press I to learn more.";
            interactUI.SetActive(true);
            DialogueManager.Instance.AddNewDialogue(dialogue, characterName, portrait);
        }
        else
        {
            hasSpokenTo = true;
        }

        if (hasSpokenTo && InventoryController.Instance.playerItems.Contains(objectItem))
        {
            DialogueManager.Instance.AddNewDialogue(spokenToDialogue, characterName, portrait);
            interactUI.transform.GetChild(0).GetComponent<TMP_Text>().text = objectItem.ItemName + " has already been added to the database.";
            interactUI.SetActive(true);
        }
    }
}
