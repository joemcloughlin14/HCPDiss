using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barrel : ObjectInteract
{
    public override void OnInteract()
    {
        base.OnInteract();              // This allows both the below debug to happen, as well as the OnInteract() commands in ObjectInteraction.
        Debug.Log("And also this");
    }
}


