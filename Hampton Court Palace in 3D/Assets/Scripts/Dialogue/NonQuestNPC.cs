using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NonQuestNPC : NPC
{
    bool hasSpokenTo;
    public string[] spokenToDialogue;

    public GameObject focusUI;
    private bool canBeInteractedWith = true;
    private bool isSpeakingTo = false;
    [SerializeField] private string JSONObjectSlug;         // this must be identical to the objectSlug in JSON file.
    private Item objectItem;

    private void Start()
    {
        hasSpokenTo = false;
        focusUI.SetActive(false);
        objectItem = ItemDatabase.Instance.GetItem(JSONObjectSlug);
    }

    public override void OnInteract()
    {
        base.OnInteract();
        
        if (hasSpokenTo)
        {
            DialogueManager.Instance.AddNewDialogue(spokenToDialogue, characterName, portrait);
            hasSpokenTo = true;
        }
        else
        {
            DialogueManager.Instance.AddNewDialogue(dialogue, characterName, portrait);
            Debug.Log("Name is " + characterName);
        }
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
        isSpeakingTo = false;
    }
}
