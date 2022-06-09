using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindEarlofSurrey : Quest
{
    void Awake()
    {
        QuestName = "My son, the troublesome fellow.";
        Description = "Find Lord Norfolk's Son, the Early of Surrey and report back with his whereabouts.";
        ItemReward = ItemDatabase.Instance.GetItem("kitchen_key");

        Goals.Add(new MeetGoal(this, "earl_of_surrey", "Find the Earl of Surrey.", false, 0, 1));

        Goals.ForEach(g => g.Init());

        completedAlreadyDialogue = new string[]
        {
            "Oh you've already seen him in the beer cellar? Of course he's there. You do appear to have your uses. Thank you friend."
        };

        inProgressDialogue = new string[]
        {
            "Having as much trouble as I am finding him eh?"
        };

        rewardDialogue = new string[]
        {
            "You've found him? Great news, where is he? In the beer cellar, of course. I hope he hasn't caused any problems for me. Thank you."
        };

        completedDialogue = new string[]
        {
            "Ah hello again, not any bad news on my son I hope?"
        };
    }
}
