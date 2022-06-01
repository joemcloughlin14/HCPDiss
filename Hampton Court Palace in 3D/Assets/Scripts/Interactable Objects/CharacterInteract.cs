using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterInteract : Interactable
{
    [SerializeField] public string JSONCharacterSlug;             // this must be identical to the objectSlug in JSON file.
    public string[] dialogue;
    public string characterName;
    public Sprite portrait;
    public bool isSpeakingTo = false;
    public bool hasSpokenTo;
    public string[] spokenToDialogue;
    public Character objectCharacter;

    private void Start()
    {
        objectCharacter = ItemDatabase.Instance.GetCharacter(JSONCharacterSlug);
    }

    public override void OnFocus()
    {
        base.OnFocus();
    }

    public override void OnInteract()
    {
        isSpeakingTo = true;
        CheckCharacterInteract();
        if (canBeInteractedWith)
        {
            isCurrentlyInteracted = true;
            InventoryController.Instance.GiveCharacter(objectCharacter);
        }
        if (isSpeakingTo)
        {
            HideFocusUI();
        }
        base.OnInteract();
    }

    public override void OnLoseFocus()
    {
        base.OnLoseFocus();
    }

    public void CheckCharacterInteract()
    {
        if (!InventoryController.Instance.databaseCharacters.Contains(objectCharacter))
        {
            InventoryController.Instance.GiveCharacter(objectCharacter);
            interactUI.transform.GetChild(0).GetComponent<TMP_Text>().text = objectCharacter.CharacterName + " has been added to the database. Press I to learn more.";
            interactUI.SetActive(true);
            DialogueManager.Instance.AddNewDialogue(dialogue, characterName, portrait);
            Debug.Log("Character added to database.");
        }
        else
        {
            hasSpokenTo = true;
        }

        if (hasSpokenTo && InventoryController.Instance.databaseCharacters.Contains(objectCharacter))
        {
            DialogueManager.Instance.AddNewDialogue(spokenToDialogue, characterName, portrait);
            interactUI.transform.GetChild(0).GetComponent<TMP_Text>().text = objectCharacter.CharacterName + " has already been added to the database.";
            interactUI.SetActive(true);
        }
    }
}
