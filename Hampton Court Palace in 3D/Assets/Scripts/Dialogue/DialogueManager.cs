using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class DialogueManager : MonoBehaviour
{
    private bool canBeInteractedWith = true;
    public static DialogueManager Instance { get; set; }
    public GameObject dialoguePanel;
    
    public bool conversationActive;

    string currentCharacterName;
    TextMeshProUGUI dialogue, characterName;
    public float textSpeed;
    List<string> currentDialogueLines = new List<string>();
    
    int dialogueIndex;
    Sprite portrait;


    void Awake()
    {
        var dialogueChild = dialoguePanel.transform.Find("DialogueText");
        dialogue = dialogueChild.GetComponent<TextMeshProUGUI>();
        
        //var characterNameChild = dialoguePanel.transform.Find("Character_Name_Panel").transform.Find("NameText");
        //characterName = characterNameChild.GetComponent<TextMeshProUGUI>();

        //var characterPortraitChild = dialoguePanel.transform.Find("Portrait");
        //portrait = characterPortraitChild.GetComponent<Image>().sprite;


        dialoguePanel.SetActive(false);
        conversationActive = false;


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
            ContinueDialogue();
        }
    }

    public void AddNewDialogue(string[] lines, string name, Sprite characterPortrait)
    {
        if (conversationActive)
        {
            return;
        }
        conversationActive = true;
        dialoguePanel.SetActive(true);
        dialogueIndex = 0;
        this.currentDialogueLines = new List<string>(lines);

        dialoguePanel.transform.Find("Portrait").GetComponent<Image>().sprite = characterPortrait;
        dialoguePanel.transform.Find("Character_Name_Panel").transform.Find("NameText").GetComponent<TextMeshProUGUI>().text = name;
    }

    public void ContinueDialogue()
    {
        if(dialogueIndex < this.currentDialogueLines.Count)
        {
            this.dialogue.text = this.currentDialogueLines[dialogueIndex];
            dialogueIndex++;
        }
        else
        {
            dialoguePanel.SetActive(false);
        }

        if (dialogueIndex == currentDialogueLines.Count)
        {
            conversationActive = false;
        }
    }

    public bool isConversationActive()
    {
        return conversationActive;
    }
}
