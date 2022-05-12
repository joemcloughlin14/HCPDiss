using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; set; }
    public GameObject dialoguePanel;

    string currentCharacterName;
    List<string> currentDialogueLines = new List<string>();

    //Button continueButton;
    TextMeshProUGUI dialogue, characterName;
    int dialogueIndex;


    void Awake()
    {
        var dialogueChild = dialoguePanel.transform.Find("DialogueText");
        dialogue = dialogueChild.GetComponent<TextMeshProUGUI>();
        var characterNameChild = dialoguePanel.transform.Find("Panel").transform.Find("NameText");
        characterName = characterNameChild.GetComponent<TextMeshProUGUI>();

        //continueButton.onClick.AddListener(delegate { ContinueDialogue(); } );
        //continueButton = dialoguePanel.transform.Find("Continue").GetComponent<Button>();

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
}