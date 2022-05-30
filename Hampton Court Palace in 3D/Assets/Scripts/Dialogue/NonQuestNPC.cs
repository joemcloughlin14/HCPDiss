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
    private bool isSpeakingTo = false;
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
        base.OnInteract();
        isSpeakingTo = true;

        if (isSpeakingTo)
        {
            focusUI.SetActive(false);
        }
        CheckInteract();
    }

    public override void OnFocus()
    {
        base.OnFocus();
        if (canBeInteractedWith && !isSpeakingTo)
        {
            focusUI.SetActive(true);
            focusUI.transform.GetChild(0).GetComponent<TMP_Text>().text = "Speak to " + objectItem.ItemName + ".";
        }
        else
        {
            focusUI.SetActive(false);
        }
    }

    public override void OnLoseFocus()
    {
        focusUI.SetActive(false);
        interactUI.SetActive(false);
        isSpeakingTo = false;
    }

    private void CheckInteract()
    {
        if (InventoryController.Instance.playerItems.Contains(objectItem))
        {
            hasSpokenTo = true;
            InventoryController.Instance.GiveItem(objectItem);
            interactUI.SetActive(true);
            if (hasSpokenTo)
            {
                DialogueManager.Instance.AddNewDialogue(spokenToDialogue, characterName, portrait);     // to sort
                Debug.Log("hasSpokenTo");
            }
            else
            {
                DialogueManager.Instance.AddNewDialogue(dialogue, characterName, portrait);
            }
        }
        else
        {
            interactUI.transform.GetChild(0).GetComponent<TMP_Text>().text = objectItem.ItemName + " has already been added to database.";
            interactUI.SetActive(true);
        }
    }
}
