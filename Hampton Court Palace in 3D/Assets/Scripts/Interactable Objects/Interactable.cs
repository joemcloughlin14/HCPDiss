using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Interactable : MonoBehaviour
{
    public GameObject interactUI;
    public GameObject focusUI;
    public GameObject questProgressUI;
    [SerializeField] private CanvasGroup focusUIGroup;
    [SerializeField] private CanvasGroup interactUIGroup;
    [SerializeField] private bool fadeOutFocus = false;
    [SerializeField] private bool fadeOutInteract = false;
    public bool canBeInteractedWith = true;
    public bool isCurrentlyInteracted = false;


    public virtual void Awake()
    {
        gameObject.layer = 9;
    }

    public virtual void OnInteract()
    {
        ShowInteractUI();
    }
    public virtual void OnFocus()
    {
        ShowFocusUI();
    }
    public virtual void OnLoseFocus()
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
        //questProgressUI.SetActive(true);
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
