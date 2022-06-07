using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddQuestToDatabase : MonoBehaviour
{
    public GameObject activeQuestDatabasePanel;

    

    private void Start()
    {
        activeQuestDatabasePanel.transform.GetComponent<TMP_Text>().text = "Current active quest: " + "'" + Quest.Instance.QuestName + "'\n - " + Quest.Instance.Description;
    }
}
