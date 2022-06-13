using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class enterRoomTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject roomLabelUI;
    [SerializeField] public string JSONRoomSlug;             // this must be identical to the objectSlug in JSON file.
    public Room objectRoom;
    [SerializeField]
    GameObject RoomDiscoveredUI;
    bool roomEntered;
    bool playerDetected;
    GameObject leaveUI;

    private void Start()
    {
        roomLabelUI.SetActive(false);
        objectRoom = ItemDatabase.Instance.GetRoom(JSONRoomSlug);
        roomEntered = false;
    }

    private void Update()
    {
        if (playerDetected)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                RoomLabelUI();
                //RoomInteractUI();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player entered trigger.");
        roomEntered = true;
        //RoomInteractUI();
        CheckRoomInteract();
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Player within trigger");
        playerDetected = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Object exited trigger");
        playerDetected = false;
        //triggerUI.SetActive(false);
    }

    public IEnumerator TurnOffInteractUITimer()
    {
        yield return new WaitForSeconds(5f);
        RoomDiscoveredUI.SetActive(false);
    }

    public IEnumerator TurnOffRoomLabel()
    {
        yield return new WaitForSeconds(5f);
        roomLabelUI.SetActive(false);
    }

    private void RoomInteractUI()
    {
        RoomDiscoveredUI.SetActive(true);
        RoomDiscoveredUI.transform.GetComponent<TMP_Text>().text = "Discovered: " + objectRoom.RoomName + ". Room has been added to the database.";
        StartCoroutine(TurnOffInteractUITimer());
    }

    private void RoomLabelUI()
    {
        roomLabelUI.SetActive(true);
        roomLabelUI.transform.GetComponent<TMP_Text>().text = "'" + objectRoom.RoomName + "'";
        StartCoroutine(TurnOffRoomLabel());
    }

    public void CheckRoomInteract()
    {
        if (!DatabaseController.Instance.databaseRooms.Contains(objectRoom))
        {
            DatabaseController.Instance.GiveRoom(objectRoom);
            RoomInteractUI();
            //RoomInteract.transform.GetComponent<TMP_Text>().text = "Discovered: " + objectRoom.RoomName + ". Room has been added to the database.";
            //RoomInteract.SetActive(true);
        }
        //else
        //{
        //    interactUI.transform.GetChild(0).GetComponent<TMP_Text>().text = objectRoom.RoomName + " has already been added to the room database.";
        //    interactUI.SetActive(true);
        //    Debug.Log("Got to part 2");
        //}
    }
}
