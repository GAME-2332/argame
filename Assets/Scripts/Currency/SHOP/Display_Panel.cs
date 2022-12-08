using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using XR;

namespace TowerShop
{

    public class Display_Panel : MonoBehaviour
    {
        [SerializeField]
        Page currentpage;
        [SerializeField]
        Button Buy;
        [SerializeField]
        Button NextPage;
         enum Page{
            tap,
            description,
            stats
            }
        [SerializeField]
        TMPro.TMP_Text Name_Text;
        [SerializeField]
        TMPro.TMP_Text TapForInfo_Text;
        [SerializeField]
        TMPro.TMP_Text Description_Text;
        [SerializeField]
        TMPro.TMP_Text Specs_Text;

        [SerializeField]
        TMPro.TMP_Text Cost_Text;

        [SerializeField]
        Image image;

        [SerializeField]
        Bank playerbank;

        [SerializeField]
        TowerSO CurrentTowerToDisplay;
        private void OnEnable()
        {
            UI_ItemBox.onClickItem += DisplayByTowerInfo;
        }

        private void OnDisable()
        {
            UI_ItemBox.onClickItem -= DisplayByTowerInfo;
        }
        private void Start()
        {
            CheckReferences();

            if(CurrentTowerToDisplay != null)
            {
                DisplayByTowerInfo(CurrentTowerToDisplay);
            }

            if (NextPage == null)
            {
                NextPage = GetComponent<Button>();
            }
            NextPage.onClick.AddListener(ClickNextPage);

            if(Buy == null)
            {
                Buy = transform.GetChild(4).GetComponent<Button>();
            }
            Buy.onClick.AddListener(BuyThis);
           
        }

        void CheckReferences()
        {
            if (playerbank == null)
            {
                playerbank = GameObject.FindGameObjectWithTag("Bank").GetComponent<Bank>();
            }
            if (Name_Text == null)
            {
                Name_Text = transform.GetChild(2).GetComponent<TMPro.TMP_Text>();
            }

            if (TapForInfo_Text == null)
            {
                TapForInfo_Text = transform.GetChild(0).GetChild(0).GetComponent<TMPro.TMP_Text>();
            }

            if (Description_Text == null)
            {
                Description_Text = transform.GetChild(0).GetChild(1).GetComponent<TMPro.TMP_Text>();
            }

            if (Specs_Text == null)
            {
                Specs_Text = transform.GetChild(0).GetChild(2).GetComponent<TMPro.TMP_Text>();
            }

            if (Cost_Text == null)
            {
                Cost_Text = transform.GetChild(3).GetComponent<TMPro.TMP_Text>();
            }

            if(image == null)
            {
                image = transform.GetChild(0).GetComponent<Image>();
            }

           
        }

        void ClickNextPage()
        {
            
            if(currentpage == Page.tap)
            {
                currentpage++;
                TapForInfo_Text.enabled = false;
                DisplayDescription();
            }
            else if (currentpage == Page.description)
            {
                currentpage++;
                DisplayStats();
            }
            else
            {
                currentpage = Page.description;
                DisplayDescription();
            }
        }

        void DisplayStats()
        {
            CheckReferences();
            image.enabled = false;
            Description_Text.enabled = false;
            Specs_Text.enabled = true;
        }

        void DisplayDescription()
        {
            CheckReferences();
            image.enabled = false;
            Description_Text.enabled = true;
            Specs_Text.enabled = false ;
        }

        public void DisplayByTowerInfo(TowerSO _info)
        {
            CurrentTowerToDisplay = _info;
            CheckReferences();
            image.enabled = true;
            image.color = Color.white;

            currentpage = Page.tap;

            TapForInfo_Text.enabled = true;
            Description_Text.enabled = false;
            Specs_Text.enabled = false;

            Name_Text.text = _info.TowerName;
            Description_Text.text = _info.Description;
            Specs_Text.text = "Attack: " + _info.TowerAttackDamage + 
                              "\n" + "Range: " + _info.TowerRange + 
                              "\n" + "Speed: " + _info.TowerAttackSpeed;
            SetUpCost(_info.TowerCost);
            Cost_Text.text ="Cost: " + _info.TowerCost;

            image.sprite = _info.Tower2dImage;
        }

        void SetUpCost(int cost)
        {
            CheckReferences();
            if(cost > playerbank.GetAmount())
            {
                Cost_Text.color = new Color32(255, 0, 0, 255);
                Buy.interactable = false;
            }
            else
            {
                Cost_Text.color = new Color32(245, 211, 68, 255);
                Buy.interactable = true;
            }
        }
        void BuyThis()
        {
            if(CurrentTowerToDisplay != null)
            {

                var selected = MainCamera.Instance.GetSelected();
                if (selected is TowerSpawnPoint)
                {
                    CheckReferences();
                    playerbank.SubtractCoins(CurrentTowerToDisplay.TowerCost);
                    SetUpCost(CurrentTowerToDisplay.TowerCost);
                    MainCamera.Instance.ClearSelected();
                    TowerSpawnPoint tower = selected as TowerSpawnPoint;
                    // Spawn tower
                    GameObject newTower = Instantiate(CurrentTowerToDisplay.TowerPrefab, tower.transform);
                    newTower.transform.localPosition = Vector3.up * .5f;
                    newTower.transform.localScale = new Vector3(1, 20, 1) * .9f;
                }

                GameObject.FindGameObjectWithTag("Bank").GetComponent<Shop_Listener>().CloseShop();
            }
        }
    }

}