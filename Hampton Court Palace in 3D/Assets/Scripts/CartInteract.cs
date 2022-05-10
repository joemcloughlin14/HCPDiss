using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CartInteract : Interactable
{
    public GameObject cartFocusUI;
    public GameObject cartInteractUI;
    private bool canBeInteractedWith = true;

    private void Start()
    {
        cartInteractUI.SetActive(false);
        cartFocusUI.SetActive(false);
    }

    public override void OnFocus()
    {
        if (canBeInteractedWith)
        {
            cartFocusUI.SetActive(true);
        }
        else
        {
            cartFocusUI.SetActive(false);
        }
    }

    public override void OnInteract()
    {
        if (canBeInteractedWith)
        {
            cartInteractUI.SetActive(!cartInteractUI.activeSelf);
        }
    }

    public override void OnLoseFocus()
    {
        cartFocusUI.SetActive(false);
        cartInteractUI.SetActive(false);
    }
}

