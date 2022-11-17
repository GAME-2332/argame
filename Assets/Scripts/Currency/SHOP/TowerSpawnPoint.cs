using DefaultNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XR;

public class TowerSpawnPoint : SelectableInteraction
{
   
    public override void Interact()
    {
        base.Interact();
        Debug.Log("opening shop");
        // Open shop
        GameObject.FindGameObjectWithTag("Bank").GetComponent<Shop_Listener>().SummonShop();

    }
}
