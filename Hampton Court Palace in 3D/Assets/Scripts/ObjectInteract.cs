using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInteract : Interactable
{
    public GameObject interactUI;
    public GameObject focusUI;
    private bool canBeInteractedWith = true;

    private void Start()
    {
        interactUI.SetActive(false);
        focusUI.SetActive(false);
    }

    public override void OnFocus()
    {
        if (canBeInteractedWith)
        {
            focusUI.SetActive(true);
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
            interactUI.SetActive(!interactUI.activeSelf);
        }
    }

    public override void OnLoseFocus()
    {
        interactUI.SetActive(false);
        focusUI.SetActive(false);
    }
}
