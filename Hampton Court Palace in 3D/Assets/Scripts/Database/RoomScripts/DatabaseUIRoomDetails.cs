using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DatabaseUIRoomDetails : MonoBehaviour
{
    Room room;                      // no value?
    Button selectedRoomButton;      // no value?
    TextMeshProUGUI roomNameText, roomDescriptionText;

    private void Start()
    {
        roomNameText = transform.Find("Room_Name").GetComponent<TextMeshProUGUI>();
        roomDescriptionText = transform.Find("Room_Description").GetComponent<TextMeshProUGUI>();
        RemoveRoom();
    }

    public void SetRoom(Room room, Button selectedButton)
    {
        gameObject.SetActive(true);
        this.room = room;
        selectedRoomButton = selectedButton;
        roomNameText.text = room.RoomName;
        roomDescriptionText.text = room.Description;
    }
    public void RemoveRoom()
    {
        gameObject.SetActive(false);
    }
}
