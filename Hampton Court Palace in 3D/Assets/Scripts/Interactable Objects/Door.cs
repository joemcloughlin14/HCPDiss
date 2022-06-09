using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : Interactable
{
    private bool isOpen = false;
    private Animator anim;
    [SerializeField] public string JSONRoomSlug;             // this must be identical to the objectSlug in JSON file.
    public Room objectRoom;
    GameObject triggerCube;

    private void Start()
    {
        anim = GetComponent<Animator>();
        interactUI.SetActive(false);
        focusUI.SetActive(false);
        objectRoom = ItemDatabase.Instance.GetRoom(JSONRoomSlug);
    }
    public override void OnFocus()
    {
        base.OnFocus();
        if (canBeInteractedWith && !isCurrentlyInteracted)
        {
            focusUI.transform.GetChild(0).GetComponent<TMP_Text>().text = "Enter " + objectRoom.RoomName;
            interactUI.transform.GetChild(0).GetComponent<TMP_Text>().text = objectRoom.addedToDatabaseString;
        }
        else
        {
            focusUI.SetActive(false);
        }
    }

    public override void OnInteract()
    {
        base.OnInteract();
        if (canBeInteractedWith)
        {
            isOpen = !isOpen;

            Vector3 doorTransformDirection = transform.TransformDirection(Vector3.forward);  // translate door's local position to world position using vector3.forward as its base.
            Vector3 playerTransformDirection = FirstPersonController.instance.transform.position - transform.position;
            float dot = Vector3.Dot(doorTransformDirection, playerTransformDirection);

            anim.SetFloat("dot", dot);
            anim.SetBool("isOpen", isOpen);

            StartCoroutine(AutoClose());
        }

        //if (canBeInteractedWith)
        //{
        //    CheckRoomInteract();
        //    isCurrentlyInteracted = true;
        //}
    }

    public override void OnLoseFocus()
    {
        base.OnLoseFocus();
        isCurrentlyInteracted = false;
    }

    private IEnumerator AutoClose()
    {
        while (isOpen)
        {
            yield return new WaitForSeconds(3);

            if (Vector3.Distance(transform.position, FirstPersonController.instance.transform.position) > 3)
            {
                isOpen = false;
                anim.SetFloat("dot", 0);
                anim.SetBool("isOpen", isOpen);
            }
        }
    }

    private void Animator_LockInteraction()
    {
        canBeInteractedWith = false;
    }

    private void Animator_UnlockInteraction()
    {
        canBeInteractedWith = true;
    }

    
}
