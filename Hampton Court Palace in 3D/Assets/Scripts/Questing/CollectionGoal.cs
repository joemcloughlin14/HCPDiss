using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionGoal : Goal
{
    public string ItemID { get; set; }
    public static CollectionGoal Instance { get; set; }

    public CollectionGoal(Quests quest, string itemID, string description, bool completed, int currentAmount, int requiredAmount)
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
            Evaluate();
        }
    }

    void ItemPickedUp(Item item)
    {
        if (item.ObjectSlug == this.ItemID)
        {
            //Debug.Log("Detected pick-up of: " + ItemID);
            this.CurrentAmount++;
            Evaluate();
        }
    }
}
