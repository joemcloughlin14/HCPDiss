using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseUI : MonoBehaviour
{
    public static DatabaseUI Instance { get; set; }
    public RectTransform databasePanel;
    public RectTransform itemScrollViewContent;
    public RectTransform characterScrollViewContent;
    public RectTransform roomScrollViewContent;
    public RectTransform questPanelContent;
    public RectTransform ButtonsPanel;
    public GameObject Dialogue;
    public GameObject questInProgressUI;
    public GameObject focusUI;
    public GameObject interactUIItem;
    public GameObject interactUICharacter;
    public GameObject interactUIRoom;
    public GameObject interactUIQuest;
    DatabaseUIItem itemContainer { get; set; }
    DatabaseUICharacter characterContainer { get; set; }
    DatabaseUIRoom roomContainer { get; set; }
    DatabaseUIQuest questContainer { get; set; }
    bool menuIsActive { get; set; }
    void Start()
    {
        characterContainer = Resources.Load<DatabaseUICharacter>("UI/Character_Container");
        itemContainer = Resources.Load<DatabaseUIItem>("UI/Item_Container");
        roomContainer = Resources.Load<DatabaseUIRoom>("UI/Room_Container");
        questContainer = Resources.Load<DatabaseUIQuest>("UI/EachQuestPanel");
        UIEventHandler.OnItemAddedToDatabase += ItemAdded;
        UIEventHandler.OnCharacterAddedToDatabase += CharacterAdded;
        UIEventHandler.OnRoomAddedToDatabase += RoomAdded;
        UIEventHandler.OnQuestAddedToDatabase += QuestAdded;
        databasePanel.gameObject.SetActive(false);
        ButtonsPanel.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            menuIsActive = !menuIsActive;

            ButtonsPanel.gameObject.SetActive(menuIsActive);
            characterScrollViewContent.gameObject.SetActive(menuIsActive);
            itemScrollViewContent.gameObject.SetActive(menuIsActive);
            roomScrollViewContent.gameObject.SetActive(menuIsActive);
            databasePanel.gameObject.SetActive(false);
            //if (QuestGiver.Instance.AssignedQuest)
            //{
                questInProgressUI.SetActive(!menuIsActive);
            //}
            //else
            //{
            //    questInProgressUI.SetActive(false);
            //}
            focusUI.SetActive(false);
            interactUIItem.SetActive(false);
            interactUICharacter.SetActive(false);
            interactUIRoom.SetActive(false);
            interactUIQuest.SetActive(false);
            

            if (menuIsActive)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Dialogue.gameObject.SetActive(false);

            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                
            }
            if(!menuIsActive && DialogueManager.Instance.conversationActive)
            {
                Dialogue.gameObject.SetActive(true);
            }
        }
    }

    void ItemAdded(Item item)
    {
        DatabaseUIItem emptyItem = Instantiate(itemContainer);
        emptyItem.SetItem(item);
        emptyItem.transform.SetParent(itemScrollViewContent);
    }

    void CharacterAdded(Character character)
    {
        DatabaseUICharacter emptyCharacter = Instantiate(characterContainer);
        emptyCharacter.SetCharacter(character);
        emptyCharacter.transform.SetParent(characterScrollViewContent);
    }

    void RoomAdded(Room room)
    {
        DatabaseUIRoom emptyRoom = Instantiate(roomContainer);
        emptyRoom.SetRoom(room);
        emptyRoom.transform.SetParent(roomScrollViewContent);
    }

    void QuestAdded(Quest quest)
    {
        DatabaseUIQuest emptyQuest = Instantiate(questContainer);
        emptyQuest.SetQuest(quest);
        emptyQuest.transform.SetParent(questPanelContent);
    }

    public bool databaseIsOpen()
    {
        return menuIsActive;
    }
}
