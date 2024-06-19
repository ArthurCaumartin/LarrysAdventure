using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private Image _eggImage;
    [SerializeField] private Color _notBoughtColor;
    [SerializeField] private Color _unSelectColor;
    [SerializeField] private Color _SelectColor;
    private ScriptableSkin _scriptableSkin;
    private Shop _shop;
    private SkinManager _skinManager;

    public void Inistialize(ScriptableSkin skin, Shop shop, SkinManager skinManager)
    {
        print("Init shop buttttttttttttttttttttttttttttttttt");
        _scriptableSkin = skin;
        _shop = shop;
        _skinManager = skinManager;

        _eggImage.sprite = skin.renderData.eggSprite;
        GetComponentInChildren<TextMeshProUGUI>().text = skin.skinName;
    }

    void Start()
    {
        print("Start shop butttttttttttttttttttt");
        GetComponent<Button>().onClick.AddListener(OnClick);
        SetSelectState(false);
    }

    public void OnClick()
    {
        _shop.OnClick(_scriptableSkin, this);
    }

    public void SetSelectState(bool value)
    {
        if (!_skinManager.IsSkinAlreadyBuy(_scriptableSkin.skinName))
        {
            print("Skin : " + _scriptableSkin.skinName + " not bought !");
            GetComponent<Image>().color = _notBoughtColor;
            return;
        }

        print("Skin is bought");
        GetComponent<Image>().color = value ? _SelectColor : _unSelectColor;
    }
}
