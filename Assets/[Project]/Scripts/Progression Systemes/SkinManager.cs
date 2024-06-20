using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    [SerializeField] private Shop _shop;
    [SerializeField] private ScriptableSkin _baseSkin;
    [SerializeField] private List<ScriptableSkin> _skinList;
    private PlayerPrefRecorder _playerPrefRecorder;
    public static ScriptableSkin CurrentSkin;
    private PlayerSkinSetter _playerSkinSetter;

    void Start()
    {
        _playerPrefRecorder = GetComponent<PlayerPrefRecorder>();
    }

    public void SetSkinFromData(ScriptableSkin baseSkin, List<ScriptableSkin> skinList)
    {
        _baseSkin = baseSkin;
        _skinList = skinList;

        SetCurrentSkinSkin(_baseSkin);

        if(!_shop)
            _shop = FindObjectOfType<Shop>();
        _shop?.LoadShop(_skinList, this);
    }

    public void SetCurrentSkinSkin(ScriptableSkin skinToSet)
    {
        if (CurrentSkin == skinToSet)
            return;

        CurrentSkin = skinToSet;
        _playerSkinSetter?.SetPlayerSkin(CurrentSkin);
    }

    public void SetSkinSetter(PlayerSkinSetter skinSetter)
    {
        _playerSkinSetter = skinSetter;
        _playerSkinSetter.SetPlayerSkin(CurrentSkin);
    }

    public List<ScriptableSkin> GetSkinList()
    {
        return _skinList;
    }

    public bool IsSkinAlreadyBuy(string skinName)
    {
        return _playerPrefRecorder.GetData(skinName) == 1;
    }

    public bool TryBuySkin(ScriptableSkin skin)
    {
        if (GameManager.instance.GetCoinQuantity() >= skin.coinPrice)
        {
            SetCurrentSkinSkin(skin);
            GameManager.instance.BuyStuff(skin.coinPrice);
            _playerPrefRecorder.SaveData(skin.skinName, 1);
            return true;
        }

        return false;
    }
}
