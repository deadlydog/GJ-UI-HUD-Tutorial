using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class CoinUI : MonoBehaviour
{
    public TMP_Text coinText;

    private void OnEnable()
    {
        PlayerCoins.CoinsChanged += CoinsChanged;
    }

    private void OnDisable()
    {
        PlayerCoins.CoinsChanged -= CoinsChanged;
    }

    private void CoinsChanged(object sender, int coins)
    {
        coinText.text = coins.ToString();
    }
}
