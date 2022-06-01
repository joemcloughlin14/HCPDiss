using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUICharacter : MonoBehaviour
{
    public Character character;
    private GameObject Character_Details;           // to sort for clicking inventory item to get rid of details panel.

    public TextMeshProUGUI characterText;
    public Image characterImage;

    public void SetCharacter(Character character)
    {
        this.character = character;
        SetUpCharacterValues();
    }

    void SetUpCharacterValues()
    {
        characterText.text = character.CharacterName;
        characterImage.sprite = Resources.Load<Sprite>("UI/Icons/Characters/" + character.CharacterSlug);
        Debug.Log(character.CharacterSlug);
        //this.transform.Find("Item_Name").GetComponent<TextMeshProUGUI>().text = item.ItemName;
    }

    public void OnSelectCharacterButton()
    {
        InventoryController.Instance.SetCharacterDetails(character, GetComponent<Button>());
    }

}

