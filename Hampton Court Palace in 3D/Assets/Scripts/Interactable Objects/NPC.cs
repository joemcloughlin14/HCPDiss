using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NPC : Interactable
{
    public string[] dialogue;
    public string characterName;
    public Sprite portrait;
    public GameObject interactUI;
    public GameObject focusUI;
    [SerializeField] private CanvasGroup focusUIGroup;
    [SerializeField] private CanvasGroup interactUIGroup;
    [SerializeField] private bool fadeOutFocus = false;
    [SerializeField] private bool fadeOutInteract = false;
    public bool isSpeakingTo = false;

    public override void OnFocus()
    {
        ShowFocusUI();
    }

    public override void OnInteract()
    {
        isSpeakingTo = true;
        ShowInteractUI();
        if (isSpeakingTo)
        {
            HideFocusUI();
        }
    }

    public override void OnLoseFocus()
    {
        HideFocusUI();
        HideInteractUI();
    }

    public void ShowFocusUI()
    {
        focusUI.SetActive(true);
        focusUIGroup.alpha = 1;
    }

    public void ShowInteractUI()
    {
        interactUI.SetActive(true);
        interactUIGroup.alpha = 1;
    }

    public void HideFocusUI()
    {
        fadeOutFocus = true;
    }

    public void HideInteractUI()
    {
        fadeOutInteract = true;
    }

    private void Update()
    {
        if (fadeOutFocus)
        {
            if (focusUIGroup.alpha >= 0)
            {
                focusUIGroup.alpha -= Time.deltaTime;
                if (focusUIGroup.alpha == 0)
                {
                    fadeOutFocus = false;
                }
            }
        }

        if (fadeOutInteract)
        {
            if (interactUIGroup.alpha >= 0)
            {
                interactUIGroup.alpha -= Time.deltaTime;
                if (interactUIGroup.alpha == 0)
                {
                    fadeOutInteract = false;
                }
            }
        }
    }
}
