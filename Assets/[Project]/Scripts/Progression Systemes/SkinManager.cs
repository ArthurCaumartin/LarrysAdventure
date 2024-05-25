using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    [SerializeField] private List<ScriptableSkin> _skinList;

    private PlayerPrefRecorder _playerPrefRecorder;
    private CurrencyManager _currencyManager;

    void Start()
    {
        _playerPrefRecorder = GetComponent<PlayerPrefRecorder>();
        _currencyManager = GetComponent<CurrencyManager>();
    }

    public List<ScriptableSkin> GetSkinList()
    {
        return _skinList;
    }

    public void BuySkin(string skinName)
    {
        _playerPrefRecorder.SaveData(skinName, 1);
    }

    public bool IsSkinAlreadyBuy(string skinName)
    {
        return _playerPrefRecorder.GetData(skinName) == 1;
    }

    public bool TryBuySkin(ScriptableSkin skin)
    {
        if (_currencyManager.CoinNumber >= skin.coinPrice)
        {
            _currencyManager.BuyStuff(skin.coinPrice);
            BuySkin(skin.skinName);
            return true;
        }

        return false;
    }
}
