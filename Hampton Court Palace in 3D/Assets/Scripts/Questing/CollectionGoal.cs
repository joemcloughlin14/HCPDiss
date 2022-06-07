using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectionGoal : Goal
{
    public string ItemID { get; set; }
    public static CollectionGoal Instance { get; set; }
    public GameObject questItemFoundUI;

    private void Start()
    {
        questItemFoundUI.SetActive(false);
    }
    public CollectionGoal(Quest quest, string itemID, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.Quest = quest;
        this.ItemID = itemID;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
    }

    public override void Init()
    {
        base.Init();
        UIEventHandler.OnItemAddedToDatabase += ItemPickedUp;
        if (DatabaseController.Instance.databaseItems.Contains(ItemDatabase.Instance.GetItem(ItemID)))
        {
            this.CurrentAmount++;
            Debug.Log("Quest item found " + ItemID);
            Evaluate();
        }
    }

    void ItemPickedUp(Item item)
    {
        if (item.ObjectSlug == this.ItemID)
        {
            //QuestUIOff();
            Debug.Log("Detected pick-up of: " + ItemID);
            //questItemFoundUI.transform.GetComponent<TMP_Text>().text = "Quest item found: " + ItemID;
            //questItemFoundUI.SetActive(true);
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
