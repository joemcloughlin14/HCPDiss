using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class Quest : MonoBehaviour
{
    public static Quest Instance { get; set; }
    public List<Goal> Goals { get; set; } = new List<Goal>();
    public string QuestName { get; set; }
    public string Description { get; set; }
    public int ExperienceReward { get; set; }
    public Item ItemReward { get; set; }
    public bool Completed { get; set; }
    
    public string[] inProgressDialogue, rewardDialogue, completedDialogue, completedAlreadyDialogue;

    public void CheckGoals()
    {
        Completed = Goals.All(g => g.Completed);
    }

    public void GiveReward()
    {
        if(ItemReward != null)
        {
            DatabaseController.Instance.GiveItem(ItemReward);
        }
    }
}
