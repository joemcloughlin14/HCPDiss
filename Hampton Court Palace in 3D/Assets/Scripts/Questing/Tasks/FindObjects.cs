using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindObjects : Quest
{
    void Awake()
    {
        QuestName = "Don't cry over lost barrels.";
        Description = "Find the lost wine barrel and definitely find the Abraham tapestry.";
        //ItemReward = ItemDatabase.Instance.GetItem("great kitchens");

        Goals.Add(new CollectionGoal(this, "wine_barrel", "Find 1 barrel", false, 0, 1));
        Goals.Add(new CollectionGoal(this, "story_of_abraham_tapestries", "Find 1 story of abraham tapestry", false, 0, 1));

        Goals.ForEach(g => g.Init());

        completedAlreadyDialogue = new string[]
        {
            "How did you know I wanted these? Well...thank you, friend."
        };

        inProgressDialogue = new string[]
        {
            "Please hurry, I really need both items or the Lord Steward will have me."
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
