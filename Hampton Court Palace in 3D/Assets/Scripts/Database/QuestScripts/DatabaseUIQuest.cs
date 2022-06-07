using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DatabaseUIQuest : MonoBehaviour
{
    public Quest quest;

    public TextMeshProUGUI questNameText;
    public TextMeshProUGUI questDescriptionText;
    public TextMeshProUGUI questProgressText;

    public void SetQuest(Quest quest)
    {
        this.quest = quest;
        SetUpQuestValues();
    }

    void SetUpQuestValues()
    {
        questNameText.text = quest.QuestName;
        questDescriptionText.text = quest.Description;
        questProgressText.text = quest.QuestName;       // to sort.
    }
}


// When a quest is assigned by interacting with a quest giver, add that quest to a list of quests.
// 
