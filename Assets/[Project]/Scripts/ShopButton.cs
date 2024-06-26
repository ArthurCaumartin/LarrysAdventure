using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private Image _eggImage;
    [SerializeField] private TextMeshProUGUI _skinNameText;
    [SerializeField] private TextMeshProUGUI _priceText;
    [Space]
    [SerializeField] private Sprite _notBoughtSprite;
    [SerializeField] private Sprite _unSelectSprite;
    [SerializeField] private Sprite _SelectSprite;
    private ScriptableSkin _scriptableSkin;
    private Shop _shop;
    private SkinManager _skinManager;

    public void Inistialize(ScriptableSkin skin, Shop shop, SkinManager skinManager)
    {
        // print("Init shop buttttttttttttttttttttttttttttttttt");
        _scriptableSkin = skin;
        _shop = shop;
        _skinManager = skinManager;

        _eggImage.sprite = skin.renderData.eggSprite;
        _skinNameText.text = skin.skinName;

        _priceText.gameObject.SetActive(true);
        _priceText.text = skin.coinPrice.ToString();
    }

    void Start()
    {
        // print("Start shop butttttttttttttttttttt");
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
            // print("Skin : " + _scriptableSkin.skinName + " not bought !");
            GetComponent<Image>().sprite = _notBoughtSprite;
            return;
        }

        // print("Skin is bought");
        _priceText.gameObject.SetActive(false);
        GetComponent<Image>().sprite = value ? _SelectSprite : _unSelectSprite;
    }
}
