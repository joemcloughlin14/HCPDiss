using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MeetGoal : Goal
{
    public string CharacterID { get; set; }
    public static MeetGoal Instance { get; set; }
    public GameObject questCharacterFoundUI;

    private void Start()
    {
        questCharacterFoundUI.SetActive(false);
    }
    public MeetGoal(Quest quest, string characterID, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.Quest = quest;
        this.CharacterID = characterID;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
    }

    public override void Init()
    {
        base.Init();
        UIEventHandler.OnCharacterAddedToDatabase += CharacterFound;
        if (DatabaseController.Instance.databaseCharacters.Contains(ItemDatabase.Instance.GetCharacter(CharacterID)))
        {
            this.CurrentAmount++;
            Debug.Log("Quest character found " + CharacterID);
            Evaluate();
        }
    }

    void CharacterFound(Character character)
    {
        if (character.CharacterSlug == this.CharacterID)
        {
            //QuestUIOff();
            Debug.Log("Detected pick-up of: " + CharacterID);
            //questCharacterFoundUI.transform.GetComponent<TMP_Text>().text = "Quest character found: " + CharacterID;
            //questCharacterFoundUI.SetActive(true);
            this.CurrentAmount++;
            Evaluate();
        }
    }

    //public IEnumerator TurnOffQuestUITimer()
    //{
    //    yield return new WaitForSeconds(5f);
    //    questItemFoundUI.SetActive(false);
    //}

    //private void QuestUIOff()
    //{
    //    questItemFoundUI.transform.GetComponent<TMP_Text>().text = "Quest item found: " + ItemID;
    //    StartCoroutine(TurnOffQuestUITimer());
    //}
}

