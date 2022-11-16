using DefaultNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XR;

public class TowerSpawnPoint : SelectableInteraction
{
    public void SetNewTower()
    {
        var selected = MainCamera.Instance.GetSelected();
        if (selected is TowerSpawnPoint)
        {
            MainCamera.Instance.ClearSelected();
            TowerSpawnPoint tower = selected as TowerSpawnPoint;
            // Spawn tower
        }
    }
    public override void Interact()
    {
        base.Interact();
        Debug.Log("opening shop");
        // Open shop
        GameObject.FindGameObjectWithTag("Bank").GetComponent<Shop_Listener>().SummonShop();

    }
}
