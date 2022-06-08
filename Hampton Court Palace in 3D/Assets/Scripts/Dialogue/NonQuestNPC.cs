using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NonQuestNPC : CharacterInteract
{
    private void Start()
    {
        hasSpokenTo = false;
        focusUI.SetActive(false);
        interactUI.SetActive(false);
        objectCharacter = ItemDatabase.Instance.GetCharacter(JSONCharacterSlug);
    }

    public override void OnInteract()
    {
        base.OnInteract();
        focusUI.SetActive(false);
        if (hasSpokenTo)
        {
            DialogueManager.Instance.AddNewDialogue(spokenToDialogue, characterName, portrait);
        }
        else
        DialogueManager.Instance.AddNewDialogue(dialogue, characterName, portrait);
        CheckCharacterInteract();
    }

    public override void OnFocus()
    {
        base.OnFocus();
        if (canBeInteractedWith && !isSpeakingTo)
        {
            
            focusUI.transform.GetChild(0).GetComponent<TMP_Text>().text = "Speak to " + objectCharacter.CharacterName + ".";
        }
        else
        {
            focusUI.SetActive(false);
        }
    }

    public override void OnLoseFocus()
    {
        base.OnLoseFocus();
        isSpeakingTo = false;
    }
}
