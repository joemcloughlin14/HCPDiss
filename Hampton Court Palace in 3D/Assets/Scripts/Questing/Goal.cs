using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal
{
    public Quests Quest { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }
    public int CurrentAmount { get; set; }
    public int RequiredAmount { get; set; }

    public virtual void Init()
    {

    }
    public void Evaluate()
    {
        if(CurrentAmount >= RequiredAmount)
        {
            checkIfComplete();
        }
    }

    public void checkIfComplete()
    {
        Completed = true;
        Quest.CheckGoals();
        Debug.Log("Goal marked as complete");
    }
}
