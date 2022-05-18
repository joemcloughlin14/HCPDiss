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

    public void CheckGoals()
    {
        Completed = Goals.All(g => g.Completed);
        if (Completed) GiveReward();
    }

    void GiveReward()
    {
        Debug.Log("Well done for completing this task.");
    }

}
