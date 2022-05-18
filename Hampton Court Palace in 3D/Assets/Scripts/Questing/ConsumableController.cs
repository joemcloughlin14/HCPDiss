using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ConsumeItem(Item item)
    {
        GameObject itemToSpawn = Instantiate(Resources.Load<GameObject>("Consumables/" + item.ObjectSlug));
        itemToSpawn.GetComponent<IConsumable>().Consume();
    }
}
