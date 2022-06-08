using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DatabaseUIItem : MonoBehaviour
{
    public Item item;

    public TextMeshProUGUI itemText;
    public Image itemImage;

    public void SetItem(Item item)
    {
        this.item = item;
        SetUpItemValues();
    }

    void SetUpItemValues()
    {
        itemText.text = item.ItemName;
        itemImage.sprite = Resources.Load<Sprite>("UI/Icons/Items/" + item.ObjectSlug);
        //this.transform.Find("Item_Name").GetComponent<TextMeshProUGUI>().text = item.ItemName;
    }

    public void OnSelectItemButton()
    {
        DatabaseController.Instance.SetItemDetails(item, GetComponent<Button>());
        Debug.Log("button works");
    }
    
}