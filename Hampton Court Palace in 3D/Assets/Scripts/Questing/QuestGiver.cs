using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestGiver : CharacterInteract
{
    public static QuestGiver Instance { get; set; }
    public bool AssignedQuest { get; set; }
    public bool Helped { get; set; }
    [SerializeField]
    private GameObject quests;
    [SerializeField]
    private string questType;
    public Quests Quest { get; set; }

    private void Start()
    {
        focusUI.SetActive(false);
        interactUI.SetActive(false);
        questInProgressUI.SetActive(false);
        objectCharacter = ItemDatabase.Instance.GetCharacter(JSONCharacterSlug);
    }

    private void LateUpdate()
    {
        if (!AssignedQuest)
        {
            questInProgressUI.SetActive(false);
        }
    }

    public override void OnInteract()
    {
        base.OnInteract();
        isSpeakingTo = true;

        if (isSpeakingTo)
        {
            HideFocusUI();
        }

        if (!AssignedQuest && !Helped)
        {
            AssignQuest();
            if (!Quest.Completed)
            {
                questInProgressUI.transform.GetComponent<TMP_Text>().text = "Quest Accepted: " + "'" + Quest.QuestName + "'\n" + Quest.Description + "\n" + CollectionGoal.Instance.ItemID;
                questInProgressUI.SetActive(true);
                DialogueManager.Instance.AddNewDialogue(dialogue, characterName, portrait);
            }
            else
            {
                DialogueManager.Instance.AddNewDialogue(Quest.completedAlreadyDialogue, characterName, portrait);
                Helped = true;
                return;
            }
            
        }
        else if (AssignedQuest && !Helped)
        {
            checkQuest();
        }
        else
        {
            DialogueManager.Instance.AddNewDialogue(Quest.completedDialogue, characterName, portrait);
            QuestUIOff();
        }
    }

    void AssignQuest()
    {
        AssignedQuest = true;
        Quest = (Quests)quests.AddComponent(System.Type.GetType(questType));
    }

    void checkQuest()
    {
        if (Quest.Completed)
        {
            Quest.GiveReward();
            AssignedQuest = false;
            Helped = true;

            QuestUIOff();
            DialogueManager.Instance.AddNewDialogue(Quest.rewardDialogue, characterName, portrait);
            Destroy((Quests)quests.GetComponent(System.Type.GetType(questType)));
        }
        else
        {
            DialogueManager.Instance.AddNewDialogue(Quest.inProgressDialogue, characterName, portrait);
        }
    }
    public override void OnFocus()
    {
        base.OnFocus();
        if (canBeInteractedWith && !isSpeakingTo && !AssignedQuest && !Helped)
        {
            focusUI.SetActive(true);
            focusUI.transform.GetChild(0).GetComponent<TMP_Text>().text = "Speak to " + objectCharacter.CharacterName + " to start a quest.";
        }
        else if (canBeInteractedWith && !isSpeakingTo && Quest.Completed && AssignedQuest)
        {
            focusUI.SetActive(true);
            focusUI.transform.GetChild(0).GetComponent<TMP_Text>().text = "Click to speak to " + objectCharacter.CharacterName + " to complete quest.";
        }
        else
        {
            focusUI.SetActive(true);
            focusUI.transform.GetChild(0).GetComponent<TMP_Text>().text = "Click to speak to " + objectCharacter.CharacterName + ".";
        }
        
    }

    public override void OnLoseFocus()
    {
        base.OnLoseFocus();
        isSpeakingTo = false;
    }

    public IEnumerator TurnOffUITimer()
    {
        yield return new WaitForSeconds(5f);
        questInProgressUI.SetActive(false);
    }

    private void QuestUIOff()
    {
        questInProgressUI.transform.GetComponent<TMP_Text>().text = "Quest: " + "'" + Quest.QuestName + "'" + " Completed.";
        StartCoroutine(TurnOffUITimer());
    }
}
