using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private bool canBeInteractedWith = true;
    public static DialogueManager Instance { get; set; }
    public GameObject dialoguePanel;
    public float textSpeed;

    string currentCharacterName;
    List<string> currentDialogueLines = new List<string>();

    TextMeshProUGUI dialogue, characterName;
    int dialogueIndex;
    public Sprite characterPortrait;
    Sprite portrait;


    void Awake()
    {
        var dialogueChild = dialoguePanel.transform.Find("DialogueText");
        dialogue = dialogueChild.GetComponent<TextMeshProUGUI>();
        var characterNameChild = dialoguePanel.transform.Find("Panel").transform.Find("NameText");
        characterName = characterNameChild.GetComponent<TextMeshProUGUI>();
        var characterPortraitChild = dialoguePanel.transform.Find("Portrait");
        portrait = characterPortraitChild.GetComponent<Image>().sprite;

        dialoguePanel.SetActive(false);


        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (this.dialogue.text == currentDialogueLines[dialogueIndex])
            {
                ContinueDialogue();
            }
            else
            {
                this.dialogue.text = currentDialogueLines[dialogueIndex];
            }
        }
    }

    public void AddNewDialogue(string[] lines, string name)
    {
        dialogueIndex = 0;
        this.currentDialogueLines = new List<string>(lines);
        this.currentCharacterName = name;
        CreateDialogue();
    }

    public void CreateDialogue()
    {
        this.dialogue.text = this.currentDialogueLines[dialogueIndex];
        this.characterName.text = this.currentCharacterName;
        dialoguePanel.SetActive(true);
    }

    public void ContinueDialogue()
    {
        if(dialogueIndex < this.currentDialogueLines.Count - 1)
        {
            dialogueIndex++;
            this.dialogue.text = this.currentDialogueLines[dialogueIndex];
        }
        else
        {
            dialoguePanel.SetActive(false);
        }
    }

    public void AddPortrait(Sprite characterPortrait)
    {
        this.characterPortrait = characterPortrait;
        dialoguePanel.transform.Find("Portrait").GetComponent<Image>().sprite = characterPortrait;
    }
}
