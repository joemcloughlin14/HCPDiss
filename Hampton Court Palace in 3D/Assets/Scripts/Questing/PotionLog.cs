using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionLog : MonoBehaviour, IConsumable
{
    public void Consume()
    {
        Debug.Log("Item interact worked");
    }
}
