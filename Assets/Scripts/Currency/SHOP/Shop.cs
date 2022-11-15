using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerShop
{

    public class Shop : MonoBehaviour
    {

        [SerializeField]
        Display_Panel panel;
        [SerializeField]
        List<TowerSO> itemList;
        [SerializeField]
        List<GameObject> items_on_display;
        [SerializeField]
        GameObject item_shelf;

        [SerializeField]
        GameObject ItemBoxPrefab;


        void Start()
        {
            if (panel == null)
            {
                panel = GameObject.FindObjectOfType<Display_Panel>();
            }
            if (item_shelf == null)
            {
                item_shelf = transform.GetChild(0).GetChild(0).gameObject;
            }
            if (ItemBoxPrefab == null)
            {
                ItemBoxPrefab = Resources.Load<GameObject>("Prefabs/TowerShop/TowerPrefabs/ITEM BOX");
            }
            GetItems();
        }

        void GetItems()
        {
            if (itemList == null || itemList.Count <= 0)
            {
                TowerSO[] allItems = Resources.LoadAll<TowerSO>("Prefabs/TowerShop/TowerSOsItems");
                itemList = new List<TowerSO>();
                foreach (TowerSO t in allItems)
                {
                    itemList.Add(t);
                }
            }

            if (ItemBoxPrefab == null)
            {
                ItemBoxPrefab = Resources.Load<GameObject>("Prefabs/TowerShop/TowerPrefabs/ITEM BOX");
            }


            for (int i = 0; i < itemList.Count; i++)
            {
                if (item_shelf == null)
                {
                    item_shelf = transform.GetChild(0).GetChild(0).gameObject;
                }
                items_on_display.Add(Instantiate(ItemBoxPrefab, item_shelf.transform));
                items_on_display[i].GetComponent<UI_ItemBox>().LoadInfo(itemList[i]);

            }

            SortItemsByPrice();


        }

        void SortItemsByPrice()
        {
            //re-arrange the transforms based on the price of its towerSO.
        }
    }


}