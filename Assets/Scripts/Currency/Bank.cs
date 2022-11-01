using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    

    [SerializeField]
    TMPro.TMP_Text BankText;

    [SerializeField]
    static int currentAmount;
    // Start is called before the first frame update
    void Start()
    {
        LoadCoins();
        if(BankText == null)
        {
            BankText = GetComponent<TMPro.TMP_Text>(); 
        }
    }

    private void OnEnable()
    {
        Enemy.OnAddCoins += AddCoins;
    }

    private void OnDisable()
    {
        Enemy.OnAddCoins -= AddCoins;
    }
    void LoadCoins()
    {
        currentAmount = 0;
        //if there is data on coins.
    }
    // Update is called once per frame

    void AddCoins(int CoinsToAdd)
    {
        if (BankText == null)
        {
            BankText = GetComponent<TMPro.TMP_Text>();
        }
        currentAmount += CoinsToAdd;
        BankText.text = currentAmount.ToString() + " Coins";

    }
}
