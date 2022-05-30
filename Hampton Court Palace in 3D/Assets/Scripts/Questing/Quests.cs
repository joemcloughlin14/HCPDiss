using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Quests : MonoBehaviour
{
    public List<Goal> Goals { get; set; } = new List<Goal>();
    public string QuestName { get; set; }
    public string Description { get; set; }
    public int ExperienceReward { get; set; }
    public Item ItemReward { get; set; }
    public bool Completed { get; set; }
    
    public string[] inProgressDialogue, rewardDialogue, completedDialogue;

    public void CheckGoals()
    {
        Completed = Goals.All(g => g.Completed);
    }

    public void GiveReward()
    {
        if(ItemReward != null)
        {
            InventoryController.Instance.GiveItem(ItemReward);
        }
    }
}
