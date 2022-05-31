using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Interactable : MonoBehaviour
{
    public GameObject interactUI;
    public GameObject focusUI;
    public string[] dialogue;
    public string characterName;
    public Sprite portrait;
    public bool isSpeakingTo = false;
    public bool hasSpokenTo;
    public string[] spokenToDialogue;
    public Item objectItem;
    public bool canBeInteractedWith = true;
    [SerializeField] private CanvasGroup focusUIGroup;
    [SerializeField] private CanvasGroup interactUIGroup;
    [SerializeField] private bool fadeOutFocus = false;
    [SerializeField] private bool fadeOutInteract = false;
    [SerializeField] public string JSONObjectSlug;             // this must be identical to the objectSlug in JSON file.

    public virtual void Awake()
    {
        gameObject.layer = 9;
    }

    public virtual void start()
    {
        objectItem = ItemDatabase.Instance.GetItem(JSONObjectSlug);
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
    }

    public void HideFocusUI()
    {
        fadeOutFocus = true;
    }

    public void HideInteractUI()
    {
        fadeOutInteract = true;
    }

    public void CheckInteract()
    {
        if (!InventoryController.Instance.playerItems.Contains(objectItem))
        {
            InventoryController.Instance.GiveItem(objectItem);
            interactUI.transform.GetChild(0).GetComponent<TMP_Text>().text = objectItem.ItemName + " has been added to the database. Press I to learn more.";
            interactUI.SetActive(true);
            DialogueManager.Instance.AddNewDialogue(dialogue, characterName, portrait);
        }
        else
        {
            hasSpokenTo = true;
        }

        if (hasSpokenTo && InventoryController.Instance.playerItems.Contains(objectItem))
        {
            DialogueManager.Instance.AddNewDialogue(spokenToDialogue, characterName, portrait);
            interactUI.transform.GetChild(0).GetComponent<TMP_Text>().text = objectItem.ItemName + " has already been added to the database.";
            interactUI.SetActive(true);
        }
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
