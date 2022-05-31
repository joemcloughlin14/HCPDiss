using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectInteract : Interactable
{
    private bool isCurrentlyInteracted = false;

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
            interactUI.transform.GetChild(0).GetComponent<TMP_Text>().text = objectItem.InitialDescription;
        }
        else
        {
            focusUI.SetActive(false);
        }
    }

    public override void OnInteract()
    {
        base.OnInteract();
        CheckInteract();
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
}
