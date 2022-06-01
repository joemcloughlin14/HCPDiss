using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseButtonsManager : MonoBehaviour
{
    public RectTransform characterDatabasePanel;
    public RectTransform itemDatabasePanel;
    //public RectTransform roomDatabasePanel;
    //public RectTransform questDatabasePanel;
    public RectTransform databasePanel;
    public void openCharacterDatabase()
    {
        if (characterDatabasePanel.gameObject.activeInHierarchy == false)
        {
            characterDatabasePanel.gameObject.SetActive(true);
            itemDatabasePanel.gameObject.SetActive(false);
            //roomDatabasePanel.gameObject.SetActive(false);
            //questDatabasePanel.gameObject.SetActive(false);
            databasePanel.gameObject.SetActive(true);
        }
        else
            characterDatabasePanel.gameObject.SetActive(false);
    }

    public void openItemDatabase()
    {
        if (itemDatabasePanel.gameObject.activeInHierarchy == false)
        {
            itemDatabasePanel.gameObject.SetActive(true);
            characterDatabasePanel.gameObject.SetActive(false);
            //roomDatabasePanel.gameObject.SetActive(false);
            //questDatabasePanel.gameObject.SetActive(false);
            databasePanel.gameObject.SetActive(true);
        }
        else
            itemDatabasePanel.gameObject.SetActive(false);
    }

    //public void openRoomDatabase()
    //{
    //    if (roomDatabasePanel.gameObject.activeInHierarchy == false)
    //    {
    //        roomDatabasePanel.gameObject.SetActive(true);
    //        characterDatabasePanel.gameObject.SetActive(false);
    //        itemDatabasePanel.gameObject.SetActive(false);
    //        questDatabasePanel.gameObject.SetActive(false);
    //        databasePanel.gameObject.SetActive(true);
    //    }
    //    else
    //        roomDatabasePanel.gameObject.SetActive(false);
    //}

    //public void openQuestDatabase()
    //{
    //    if (questDatabasePanel.gameObject.activeInHierarchy == false)
    //    {
    //        questDatabasePanel.gameObject.SetActive(true);
    //        characterDatabasePanel.gameObject.SetActive(false);
    //        itemDatabasePanel.gameObject.SetActive(false);
    //        roomDatabasePanel.gameObject.SetActive(false);
    //        databasePanel.gameObject.SetActive(true);
    //    }
    //    else
    //        questDatabasePanel.gameObject.SetActive(false);
    //}
}
