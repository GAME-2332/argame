using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerShop
{

    public class UI_Shop_Bank : MonoBehaviour
    {
        [SerializeField]
        TMPro.TMP_Text bank_text;
        [SerializeField]
        Bank playerbank;
        // Start is called before the first frame update
        void Start()
        {
            if (playerbank == null)
            {
                playerbank = GameObject.FindGameObjectWithTag("Bank").GetComponent<Bank>();
            }
            if (bank_text == null)
            {
                bank_text = GetComponent<TMPro.TMP_Text>();
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (playerbank != null)
            {
                if (bank_text != null)
                    bank_text.text = playerbank.GetAmount().ToString();
            }
        }
    }

}