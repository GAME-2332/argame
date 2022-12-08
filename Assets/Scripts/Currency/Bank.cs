using System;
using Persistence;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bank : MonoBehaviour//, IRuntimeSerialized
{
    
    TMPro.TMP_Text BankText;

    [SerializeField]
    int currentAmount;
    // Start is called before the first frame update
    void Start()
    {
        if(BankText == null)
        {
            BankText = GetComponent<TMPro.TMP_Text>(); 
        }
    }

    private void Update() {
        LoadCoins();
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
        if (BankText == null)
        {
            BankText = GetComponent<TMPro.TMP_Text>();
        }
        BankText.text = currentAmount.ToString() + " Coins";
        //if there is data on coins.
    }
    // Update is called once per frame

    public void AddCoins(int CoinsToAdd)
    {
        if (BankText == null)
        {
            BankText = GetComponent<TMPro.TMP_Text>();
        }
        currentAmount += CoinsToAdd;
        BankText.text = currentAmount.ToString() + " Coins";

    }

    public int GetAmount()
    {
        return currentAmount;
    }

    public void SubtractCoins(int CoinsToSubtract)
    {
        currentAmount -= CoinsToSubtract;
        BankText.text = currentAmount.ToString() + " Coins";
    }

    public string GetSerializedName()
    {
        return "Bank";
    }
}
