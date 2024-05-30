using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    [SerializeField] private int _coinNumber;

    public int CoinNumber
    {
        get => _coinNumber;

        set
        {
            _coinNumber = value;
            foreach (var item in _coinTextList)
                item.text = "Coin : " + _coinNumber.ToString();
        }
    }

    [SerializeField] private List<TextMeshProUGUI> _coinTextList;

    void Start()
    {
        foreach (var item in _coinTextList)
            item.text = "Coin : " + _coinNumber.ToString();
    }

    public void BuyStuff(int value)
    {
        CoinNumber -= value;
    }
}
