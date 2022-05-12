using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; set; }
    public GameObject dialoguePanel;
    public float textSpeed;

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
                StopAllCoroutines();
                this.dialogue.text = currentDialogueLines[dialogueIndex];
            }
        }
    }

    public void AddNewDialogue(string[] dialogue, string name)
    {
        dialogueIndex = 0;
        this.currentDialogueLines = new List<string>(currentDialogueLines);
        this.currentCharacterName = name;
        StartCoroutine(TypeLine());
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
            StartCoroutine(TypeLine());
        }
        else
        {
            dialoguePanel.SetActive(false);
        }
    }

    IEnumerator TypeLine()
    {
        foreach (char c in currentDialogueLines[dialogueIndex].ToCharArray())
        {
            this.dialogue.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
