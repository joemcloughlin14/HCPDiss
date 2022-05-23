using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindObjects : Quests
{
    void Start()
    {
        QuestName = "Object Finder";
        Description = "Find this item.";
        ItemReward = ItemDatabase.Instance.GetItem("potion_log");

        Goals.Add(new CollectionGoal(this, "potion_log", "Find 5 items", false, 0, 5));
        Goals.Add(new CollectionGoal(this, "sword", "Find 2 other items", false, 0, 2));

        Goals.ForEach(g => g.Init());
    }


}
