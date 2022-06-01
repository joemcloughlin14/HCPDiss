using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectInteract : Interactable
{
   
    [SerializeField] public string JSONObjectSlug;             // this must be identical to the objectSlug in JSON file.
    public Item objectItem;

    private void Start()
    {
        interactUI.SetActive(false);
        focusUI.SetActive(false);
        objectItem = ItemDatabase.Instance.GetItem(JSONObjectSlug);
    }

    public override void OnFocus()
    {
        base.OnFocus();
        if (canBeInteractedWith && !isCurrentlyInteracted)
        {
            focusUI.transform.GetChild(0).GetComponent<TMP_Text>().text = "Noteworthy Item: " + objectItem.ItemName + " - Click to add to database.";
            interactUI.transform.GetChild(0).GetComponent<TMP_Text>().text = objectItem.addedToDatabaseString;
        }
        else
        {
            focusUI.SetActive(false);
        }
    }

    public override void OnInteract()
    {
        base.OnInteract();
        CheckItemInteract();
        if (canBeInteractedWith)
        {
            isCurrentlyInteracted = true;
            InventoryController.Instance.GiveItem(objectItem);
        }
    }

    public override void OnLoseFocus()
    {
        base.OnLoseFocus();
        isCurrentlyInteracted = false;
    }

    public void CheckItemInteract()
    {
        if (!InventoryController.Instance.databaseItems.Contains(objectItem))
        {
            InventoryController.Instance.GiveItem(objectItem);
            interactUI.transform.GetChild(0).GetComponent<TMP_Text>().text = objectItem.ItemName + " has been added to the database. Press I to learn more.";
            interactUI.SetActive(true);
            //DialogueManager.Instance.AddNewDialogue(dialogue, characterName, portrait);
        }
        else
        {
            //DialogueManager.Instance.AddNewDialogue(spokenToDialogue, characterName, portrait);
            interactUI.transform.GetChild(0).GetComponent<TMP_Text>().text = objectItem.ItemName + " has already been added to the database.";
            interactUI.SetActive(true);
        }
    }
}
