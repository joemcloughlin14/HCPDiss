using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUIDetailsCh : MonoBehaviour
{
    Character character;
    Button selectedCharacterButton;
    TextMeshProUGUI characterNameText, characterDescriptionText;

    private void Start()
    {
        characterNameText = transform.Find("Character_Name").GetComponent<TextMeshProUGUI>();
        characterDescriptionText = transform.Find("Character_Description").GetComponent<TextMeshProUGUI>();
        RemoveCharacter();
    }

    public void SetCharacter(Character character, Button selectedButton)
    {
        gameObject.SetActive(true);
        this.character = character;
        selectedCharacterButton = selectedButton;
        characterNameText.text = character.CharacterName;
        characterDescriptionText.text = character.Description;
    }
    public void RemoveCharacter()
    {
        gameObject.SetActive(false);
    }

}

