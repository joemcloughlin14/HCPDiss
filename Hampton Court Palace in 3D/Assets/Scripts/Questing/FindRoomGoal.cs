using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FindRoomGoal : Goal
{
    public string RoomID { get; set; }
    public static FindRoomGoal Instance { get; set; }
    public GameObject questRoomFoundUI;

    private void Start()
    {
        questRoomFoundUI.SetActive(false);
    }
    public FindRoomGoal(Quest quest, string roomID, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.Quest = quest;
        this.RoomID = roomID;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
    }

    public override void Init()
    {
        base.Init();
        UIEventHandler.OnRoomAddedToDatabase += RoomFound;
        if (DatabaseController.Instance.databaseRooms.Contains(ItemDatabase.Instance.GetRoom(RoomID)))
        {
            this.CurrentAmount++;
            Debug.Log("Quest room found " + RoomID);
            Evaluate();
        }
    }

    void RoomFound(Room room)
    {
        if (room.RoomSlug == this.RoomID)
        {
            //QuestUIOff();
            Debug.Log("Detected entering of: " + RoomID);
            //questCharacterFoundUI.transform.GetComponent<TMP_Text>().text = "Quest character found: " + CharacterID;
            //questCharacterFoundUI.SetActive(true);
            this.CurrentAmount++;
            Evaluate();
        }
    }

    //public IEnumerator TurnOffQuestUITimer()
    //{
    //    yield return new WaitForSeconds(5f);
    //    questItemFoundUI.SetActive(false);
    //}

    //private void QuestUIOff()
    //{
    //    questItemFoundUI.transform.GetComponent<TMP_Text>().text = "Quest item found: " + ItemID;
    //    StartCoroutine(TurnOffQuestUITimer());
    //}
}

