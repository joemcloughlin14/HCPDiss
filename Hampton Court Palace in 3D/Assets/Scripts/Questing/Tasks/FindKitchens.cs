using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindKitchens : Quest
{
    void Awake()
    {
        QuestName = "The greatest kitchens in all the land";
        Description = "Find the Great Kitchens and explore.";
        //ItemReward = ItemDatabase.Instance.GetItem("great kitchens");

        Goals.Add(new FindRoomGoal(this, "great_kitchens", "Find the Great Kitchens.", false, 0, 1));

        Goals.ForEach(g => g.Init());

        completedAlreadyDialogue = new string[]
        {
            "Well, I'm glad you've already seen them. Magnificent aren't they?"
        };

        inProgressDialogue = new string[]
        {
            "They're on the ground floor, to the east side of the palace."
        };

        rewardDialogue = new string[]
        {
            "So, what did you think? Did you have a good lookaround? They're quite large aren't they? Magnificent."
        };

        completedDialogue = new string[]
        {
            "In nomine Patris et Filii et Spiritus Sancti."
        };
    }
}

