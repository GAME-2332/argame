using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace TowerShop {

    public class UI_ItemBox : MonoBehaviour
    {
        public delegate void ClickedItem(TowerSO _myinfo);
        public static event ClickedItem onClickItem;

        [SerializeField]
        TMPro.TMP_Text price_text;
        [SerializeField]
        Image item_image;
        [SerializeField]
        TowerSO _myinfo;
        [SerializeField]
        Button _button;
        // Start is called before the first frame update
        void Start()
        {
            GetReferences();
        }

        void GetReferences()
        {
            if(price_text == null)
            {
                price_text = GetComponentInChildren<TMPro.TMP_Text>();
            }
            if(item_image == null)
            {
                item_image = transform.GetChild(0).GetComponent<Image>();
            }
            if(_button == null)
            {
                _button = GetComponent<Button>();
            }
            _button.onClick.AddListener(CallDisplay);
        }

        void CallDisplay()
        {
            Debug.Log(_myinfo.TowerName);
            onClickItem(_myinfo);

        }
        public void LoadInfo(TowerSO _item)
        {
            if (price_text == null)
            {
                price_text = GetComponentInChildren<TMPro.TMP_Text>();
            }
            if (item_image == null)
            {
                item_image = transform.GetChild(0).GetComponent<Image>();
            }
            item_image.sprite = _item.Tower2dImage;
            price_text.text = _item.TowerCost.ToString();
            _myinfo = _item;
        }
    }


}
