using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class isTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject triggerUI;
    [SerializeField] public string JSONRoomSlug;             // this must be identical to the objectSlug in JSON file.
    public Room objectRoom;
    [SerializeField]
    GameObject interactUI;
    bool roomEntered;
    bool playerDetected;
    GameObject leaveUI;

    private void Start()
    {
        triggerUI.SetActive(false);
        objectRoom = ItemDatabase.Instance.GetRoom(JSONRoomSlug);
        roomEntered = false;
    }

    private void Update()
    {
        if (playerDetected)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                RoomFoundUIO();
                CheckRoomInteract();
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player entered trigger.");
        
        RoomFoundUIO();
        roomEntered = true;
  
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

    public IEnumerator TurnOffUITimer()
    {
        yield return new WaitForSeconds(5f);
        triggerUI.SetActive(false);
    }

    private void RoomFoundUIO()
    {
        triggerUI.SetActive(true);
        triggerUI.transform.GetComponent<TMP_Text>().text = "'" + objectRoom.RoomName + "'";
        StartCoroutine(TurnOffUITimer());
    }

    public void CheckRoomInteract()
    {
        if (!DatabaseController.Instance.databaseRooms.Contains(objectRoom))
        {
            DatabaseController.Instance.GiveRoom(objectRoom);
            interactUI.transform.GetChild(0).GetComponent<TMP_Text>().text = objectRoom.RoomName + " has been added to the room database. Press I to learn more.";
            interactUI.SetActive(true);
        }
        //else
        //{
        //    interactUI.transform.GetChild(0).GetComponent<TMP_Text>().text = objectRoom.RoomName + " has already been added to the room database.";
        //    interactUI.SetActive(true);
        //    Debug.Log("Got to part 2");
        //}
    }
}
