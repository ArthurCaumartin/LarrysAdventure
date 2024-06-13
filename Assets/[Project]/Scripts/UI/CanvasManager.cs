using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GridLayout _levelButtonLayout;
    [SerializeField] private GameObject _levelButtonPrefab;
    private InGameUI _inGameUi;

    public void SetCoinText(int coinQuantity)
    {
        _inGameUi?.SetCoinText(coinQuantity);
    }

    public void SetLevelButtonInMenu(List<Level> levelList)
    {
        
    }

    public void SetInGameUi(InGameUI value)
    {
        _inGameUi = value;

        SetCoinText(GameManager.instance.GetCoinQuantity());
    }
}
