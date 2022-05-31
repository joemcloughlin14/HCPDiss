using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NPC : Interactable
{
    public override void OnFocus()
    {
        base.OnFocus();
    }

    public override void OnInteract()
    {
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
    }
}
