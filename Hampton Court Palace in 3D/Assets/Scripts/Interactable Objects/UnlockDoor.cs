using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnlockDoor : Interactable
{

    [SerializeField] public string JSONObjectSlug;             // this must be identical to the objectSlug in JSON file.
    [SerializeField] public string unlockKeyJSON;             // this must be identical to the objectSlug in JSON file.
    public Item objectItem;
    [SerializeField] GameObject lockedDoorObject;
    [SerializeField] GameObject unlockedUI;
    [SerializeField] public string JSONRoomSlug;             // this must be identical to the objectSlug in JSON file.
    public Room objectRoom;
    public Item unlockItem;

    private void Start()
    {
        unlockedUI.SetActive(false);
        interactUI.SetActive(false);
        focusUI.SetActive(false);
        objectRoom= ItemDatabase.Instance.GetRoom(JSONRoomSlug);
        objectItem = ItemDatabase.Instance.GetItem(JSONObjectSlug);
        unlockItem = ItemDatabase.Instance.GetItem(unlockKeyJSON);
    }

    public override void OnFocus()
    {
        base.OnFocus();
        if (canBeInteractedWith && !isCurrentlyInteracted)
        {
            focusUI.transform.GetChild(0).GetComponent<TMP_Text>().text = "This is a " + objectItem.ItemName;
            interactUI.transform.GetChild(0).GetComponent<TMP_Text>().text = objectItem.addedToDatabaseString;
        }
        else
        {
            HideFocusUI();
        }
    }

    public override void OnInteract()
    {
        base.OnInteract();

        if (canBeInteractedWith && DatabaseController.Instance.databaseItems.Contains(unlockItem))
        {
            Destroy(lockedDoorObject);      // unlocks door
            RoomUnlockedUI();
            interactUI.SetActive(false);
        }

        else
        {
            interactUI.transform.GetChild(0).GetComponent<TMP_Text>().text = objectItem.addedToDatabaseString;
            interactUI.SetActive(true);
            isCurrentlyInteracted = true;
        }
    }

    public override void OnLoseFocus()
    {
        base.OnLoseFocus();
        isCurrentlyInteracted = false;
    }

    public IEnumerator TurnOffUnlockedUITimer()
    {
        yield return new WaitForSeconds(5f);
        unlockedUI.SetActive(false);
    }

    private void RoomUnlockedUI()
    {
        unlockedUI.SetActive(true);
        unlockedUI.transform.GetComponent<TMP_Text>().text = "You have unlocked the " + objectRoom.RoomName + "!\n" + "You may now access this area.";
        StartCoroutine(TurnOffUnlockedUITimer());
    }
}

