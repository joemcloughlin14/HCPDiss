using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DatabaseUIRoom : MonoBehaviour
{
    public Room room;

    public TextMeshProUGUI roomText;
    public Image roomImage;

    public void SetRoom(Room room)
    {
        this.room = room;
        SetUpRoomValues();
    }

    void SetUpRoomValues()
    {
        roomText.text = room.RoomName;
        roomImage.sprite = Resources.Load<Sprite>("UI/Icons/Rooms/" + room.RoomSlug);
    }

    public void OnSelectRoomButton()
    {
        DatabaseController.Instance.SetRoomDetails(room, GetComponent<Button>());
        Debug.Log("Button works");
    }

}
