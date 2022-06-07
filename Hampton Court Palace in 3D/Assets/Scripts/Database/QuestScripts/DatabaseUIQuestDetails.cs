using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DatabaseUIQuestDetails : MonoBehaviour
{
    Quest quest;                      // no value?
    TextMeshProUGUI questNameText, questDescriptionText, questProgressText;

    private void Start()
    {
        questNameText = transform.Find("QuestNameText").GetComponent<TextMeshProUGUI>();
        questDescriptionText = transform.Find("QuestDescriptionText").GetComponent<TextMeshProUGUI>();
        questProgressText = transform.Find("QuestProgressText").GetComponent<TextMeshProUGUI>();
        Debug.Log("Found these: " + questNameText);
        RemoveItem();
    }

    public void SetQuest(Quest quest)
    {
        gameObject.SetActive(true);
        this.quest = quest;
        questNameText.text = quest.QuestName;
        questDescriptionText.text = quest.Description;
        questProgressText.text = quest.QuestName;           // to change
    }
    public void RemoveItem()
    {
        gameObject.SetActive(false);
    }
}
