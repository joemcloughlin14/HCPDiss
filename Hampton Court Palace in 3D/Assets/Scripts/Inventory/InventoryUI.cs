using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public RectTransform inventoryPanel;
    public RectTransform scrollViewContent;
    public GameObject Dialogue;
    InventoryUIItem itemContainer { get; set; }
    bool menuIsActive { get; set; }
    Item currentSelectedItem { get; set; }

    void Start()
    {
        itemContainer = Resources.Load<InventoryUIItem>("UI/Item_Container");
        UIEventHandler.OnItemAddedToInventory += ItemAdded;
        inventoryPanel.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            menuIsActive = !menuIsActive;
            
            inventoryPanel.gameObject.SetActive(menuIsActive);
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
        emptyItem.transform.SetParent(scrollViewContent);
    }

    public bool inventoryIsOpen()
    {
        return menuIsActive;
    }
}
