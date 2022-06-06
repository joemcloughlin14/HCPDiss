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

    public override void OnFocus()
    {
        base.OnFocus();
    }

    public override void OnInteract()
    {
        if (canBeInteractedWith)
        {
            CheckCharacterInteract();
            isCurrentlyInteracted = true;
            if (hasSpokenTo && DatabaseController.Instance.databaseCharacters.Contains(objectCharacter))
            {
                interactUI.transform.GetChild(0).GetComponent<TMP_Text>().text = objectCharacter.CharacterName + " has already been added to the character database.";
                interactUI.SetActive(true);
            }
        }

        isSpeakingTo = true;
        if (isSpeakingTo)
        {
            HideFocusUI();
        }
        base.OnInteract();
    }

    public override void OnLoseFocus()
    {
        base.OnLoseFocus();
        isCurrentlyInteracted = false;
    }

    public void CheckCharacterInteract()
    {
        if (!DatabaseController.Instance.databaseCharacters.Contains(objectCharacter))
        {
            DatabaseController.Instance.GiveCharacter(objectCharacter);
            interactUI.transform.GetChild(0).GetComponent<TMP_Text>().text = objectCharacter.CharacterName + " has been added to the database. Press I to learn more.";
            interactUI.SetActive(true);
        }
        else
        {
            hasSpokenTo = true;
        }
    }
}
