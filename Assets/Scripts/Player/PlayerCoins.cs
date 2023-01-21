using UnityEngine;
using System;

public class PlayerCoins : MonoBehaviour
{
    public static EventHandler<int> CoinsChanged;

    private int coins = 0;
    public int Coins
    {
        get { return coins; }
        set
        {
            coins = value;
            CoinsChanged?.Invoke(this, coins);
        }
    }

    private void OnEnable()
    {
        Coins = 0;
    }
}
