using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerShop
{

    public class UI_BackButton : MonoBehaviour
    {
        [SerializeField]
        Button _button;
        // Start is called before the first frame update
        void Start()
        {
            if(_button == null)
            {
                _button = GetComponent<Button>();
            }
            _button.onClick.AddListener(CloseShop);
        }

        void CloseShop()
        {
            GameObject.FindGameObjectWithTag("Bank").GetComponent<Shop_Listener>().CloseShop();
        }
    }

}