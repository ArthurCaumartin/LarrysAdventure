using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    [SerializeField] private TextMeshProUGUI _menuCoinText;
    private InGameUI _inGameUi;

    void Awake()
    {
        instance = this;
    }

    public void SetCoinText(int coinQuantity)
    {
        if (_menuCoinText)
            _menuCoinText.text = coinQuantity.ToString();
            
        _inGameUi?.SetCoinText(coinQuantity);
    }

    public void SetInGameUi(InGameUI newInGameUi)
    {
        _inGameUi = newInGameUi;
        SetCoinText(GameManager.instance.GetCoinQuantity());
    }
}
