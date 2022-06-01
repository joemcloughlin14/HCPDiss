using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public RectTransform inventoryPanel;
    public RectTransform itemScrollViewContent;
    public RectTransform characterScrollViewContent;
    public GameObject Dialogue;
    public RectTransform ButtonsPanel;
    InventoryUIItem itemContainer { get; set; }
    InventoryUICharacter characterContainer { get; set; }
    bool menuIsActive { get; set; }
    Item currentSelectedItem { get; set; }
    Character currentSelectedCharacter { get; set; }

    void Start()
    {
        characterContainer = Resources.Load<InventoryUICharacter>("UI/Character_Container");
        itemContainer = Resources.Load<InventoryUIItem>("UI/Item_Container");
        UIEventHandler.OnItemAddedToInventory += ItemAdded;
        UIEventHandler.OnCharacterAddedToInventory += CharacterAdded;
        inventoryPanel.gameObject.SetActive(false);
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
            inventoryPanel.gameObject.SetActive(false);
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
        InventoryUIItem emptyItem = Instantiate(itemContainer);
        emptyItem.SetItem(item);
        emptyItem.transform.SetParent(itemScrollViewContent);
    }

    void CharacterAdded(Character character)
    {
        InventoryUICharacter emptyCharacter = Instantiate(characterContainer);
        emptyCharacter.SetCharacter(character);
        emptyCharacter.transform.SetParent(characterScrollViewContent);
    }

    public bool inventoryIsOpen()
    {
        return menuIsActive;
    }
}
