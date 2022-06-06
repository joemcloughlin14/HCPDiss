using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DatabaseUICharacter : MonoBehaviour
{
    public Character character;
    //public RectTransform Character_Details;           // to sort for clicking inventory item to get rid of details panel.

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
    }

    public void OnSelectCharacterButton()
    {
        //if (Character_Details.gameObject.activeInHierarchy == true)
        //{
        //    Character_Details.gameObject.SetActive(false);
        //}
        DatabaseController.Instance.SetCharacterDetails(character, GetComponent<Button>());
        Debug.Log("Button works");
    }

}

