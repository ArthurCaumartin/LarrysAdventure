using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    [SerializeField] private int _coinNumber;
    public int CoinNumber { get => _coinNumber;}

    public void BuyStuff(int value)
    {
        _coinNumber -= value;
    }
}
