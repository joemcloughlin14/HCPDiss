using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : Interactable
{
    public Item ItemFound { get; set; }
    public override void OnFocus()
    {
        Debug.Log("This item can be added to your inventory.");
    }

    public override void OnInteract()
    {
        InventoryController.Instance.GiveItem(ItemFound);
        Destroy(gameObject);
    }

    public override void OnLoseFocus()
    {
        
    }
}
