using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public Quest Quest { get; set; }
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
            markAsComplete();
        }
    }

    public void markAsComplete()
    {
        Completed = true;
        Quest.CheckGoals();
    }
}
