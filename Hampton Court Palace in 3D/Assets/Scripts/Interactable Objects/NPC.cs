using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public string[] dialogue;
    public string characterName;
    public Sprite portrait;

    public override void OnFocus()
    {
        
    }

    public override void OnInteract()
    {
        Debug.Log("Interacting with NPC class");
        DialogueManager.Instance.AddNewDialogue(dialogue, characterName);
        DialogueManager.Instance.AddPortrait(portrait);
    }

    public override void OnLoseFocus()
    {
       
    }
}
