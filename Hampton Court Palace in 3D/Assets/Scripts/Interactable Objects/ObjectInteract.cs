using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectInteract : Interactable
{
    public GameObject interactUI;
    public GameObject focusUI;
    private bool canBeInteractedWith = true;
    private bool isCurrentlyInteracted = false;
    [SerializeField] private string JSONObjectSlug;         // this must be identical to the objectSlug in JSON file.
    private Item objectItem;

    private void Start()
    {
        interactUI.SetActive(false);
        focusUI.SetActive(false);
        objectItem = ItemDatabase.Instance.GetItem(JSONObjectSlug);
    }

    public override void OnFocus()
    {
        if (canBeInteractedWith && !isCurrentlyInteracted)
        {
            focusUI.SetActive(true);
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
        if (canBeInteractedWith)
        {
            isCurrentlyInteracted = true;
            interactUI.SetActive(!interactUI.activeSelf);
            focusUI.SetActive(false);
            InventoryController.Instance.GiveItem(objectItem);
        }
    }

    public override void OnLoseFocus()
    {
        interactUI.SetActive(false);
        focusUI.SetActive(false);
        isCurrentlyInteracted = false;
    }
}
