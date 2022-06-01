using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public RectTransform InventoryPanel;
    public RectTransform itemScrollViewContent;
    public RectTransform characterScrollViewContent;
    public GameObject Dialogue;
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
        InventoryPanel.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            menuIsActive = !menuIsActive;
            
            InventoryPanel.gameObject.SetActive(menuIsActive);
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
