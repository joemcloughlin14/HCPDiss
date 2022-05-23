using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : ObjectInteract
{  
    public override void OnInteract()
    {
        base.OnInteract();
        Debug.Log("Added to inventory");
        InventoryController.Instance.GiveItem("potion_log");
    }

    public override void OnFocus()
    {
        base.OnFocus();
    }

    public override void OnLoseFocus()
    {
        base.OnLoseFocus();
    }
}
