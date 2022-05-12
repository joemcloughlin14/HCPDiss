using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public string[] dialogue;
    public string characterName;

    public override void OnFocus()
    {
        
    }

    public override void OnInteract()
    {
        Debug.Log("Interacting with NPC class");
        DialogueManager.Instance.AddNewDialogue(dialogue, characterName);
    }

    public override void OnLoseFocus()
    {
       
    }
}
