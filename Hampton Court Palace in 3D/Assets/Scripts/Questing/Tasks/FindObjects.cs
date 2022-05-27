using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindObjects : Quests
{
    void Start()
    {
        Debug.Log("Find one barrel and one Great Kitchens.");
        QuestName = "Object Finder";
        Description = "Find these items.";
        ItemReward = ItemDatabase.Instance.GetItem("story_of_abraham_tapestries");

        Goals.Add(new CollectionGoal(this, "old_barrel", "Find 1 barrel", false, 0, 1));
        Goals.Add(new CollectionGoal(this, "great_kitchens", "Find 1 great kitchens", false, 0, 1));

        Goals.ForEach(g => g.Init());

        inProgressDialogue = new string[]
        {
            "Please hurry, I really need that barrel or the Lord Steward will have me."
        };

        rewardDialogue = new string[]
        {
            "Oh thank you, thank you! I shan't be letting this out of my sight again! I am most grateful to you."
        };

        completedDialogue = new string[]
        {
            "You'll be pleased to hear, I still have the barrel safe. Thank you, again."
        };
    }
}
