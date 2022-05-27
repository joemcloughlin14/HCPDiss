using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestGiver : NPC
{
    public bool AssignedQuest { get; set; }
    public bool Helped { get; set; }
    //private bool isCurrentlyInteracted = false;
    public GameObject focusUI;
    private bool canBeInteractedWith = true;
    private bool isSpeakingTo = false;
    [SerializeField] private string JSONObjectSlug;         // this must be identical to the objectSlug in JSON file.
    private Item objectItem;

    [SerializeField]
    private GameObject quests;
    [SerializeField]
    private string questType;
    public Quests Quest { get; set; }

    private void Start()
    {
        focusUI.SetActive(false);
        objectItem = ItemDatabase.Instance.GetItem(JSONObjectSlug);
    }

    public override void OnInteract()
    {
            base.OnInteract();
        isSpeakingTo = true;        // sort this.
            if (!AssignedQuest && !Helped)
            {
                DialogueManager.Instance.AddNewDialogue(dialogue, characterName, portrait);
                AssignQuest();
                Debug.Log("characterName is also " + characterName);
            Debug.Log("name is " + name);
            }
            else if (AssignedQuest && !Helped)
            {
                Debug.Log(Quest.Completed);
                checkQuest();
            }
            else
            {
                Debug.Log("PASSED ALL CHECKS.");
                DialogueManager.Instance.AddNewDialogue(Quest.completedDialogue, characterName, portrait);
            }
    }

    void AssignQuest()
    {
        AssignedQuest = true;
        Quest = (Quests)quests.AddComponent(System.Type.GetType(questType));
    }

    void checkQuest()
    {
        Debug.Log(Quest.Completed + " at this point.");
        if (Quest.Completed)
        {
            Debug.Log("Quest complete");
            Quest.GiveReward();
            AssignedQuest = false;
            Helped = true;
            
            DialogueManager.Instance.AddNewDialogue(Quest.rewardDialogue, characterName, portrait);
            Destroy((Quests)quests.GetComponent(System.Type.GetType(questType)));
        }
        else
        {
            Debug.Log("Not complete");
            DialogueManager.Instance.AddNewDialogue(Quest.inProgressDialogue, characterName, portrait);
        }
    }
    public override void OnFocus()
    {
        base.OnFocus();
        if (canBeInteractedWith && !isSpeakingTo && !AssignedQuest && !Helped)
        {
            focusUI.SetActive(true);
            focusUI.transform.GetChild(0).GetComponent<TMP_Text>().text = "Speak to " + objectItem.ItemName + " to start a quest.";
        }
        else if (canBeInteractedWith && !isSpeakingTo && Quest.Completed && AssignedQuest)
        {
            focusUI.SetActive(true);
            focusUI.transform.GetChild(0).GetComponent<TMP_Text>().text = "Click to speak to " + objectItem.ItemName + " to complete quest.";
        }
        else
        {
            focusUI.SetActive(true);
            focusUI.transform.GetChild(0).GetComponent<TMP_Text>().text = "Click to speak to " + objectItem.ItemName + ".";
        }
        
    }

    public override void OnLoseFocus()
    {
        focusUI.SetActive(false);
        isSpeakingTo = false;
    }
}
