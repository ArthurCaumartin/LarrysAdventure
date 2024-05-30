using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    //TODO Layout height set with _scriptableSkinList.count

    [SerializeField] private GameObject _skinButtonPrefabs;
    [Space]
    [SerializeField] private ScrollRect _scrollRect;
    [SerializeField] private RectTransform _shopContainer;
    [SerializeField] private RectTransform _shopBackground;
    [SerializeField] private RectTransform _shopButtonLayout;
    [Space]
    private List<ScriptableSkin> _scriptableSkinList;
    private List<ShopButton> _shopButtonList = new List<ShopButton>();
    private bool _isShopOpen = true;

    private SkinManager _skinManager;

    private void Start()
    {
        _skinManager = GameManager.instance.GetComponent<SkinManager>();
        _scriptableSkinList = _skinManager.GetSkinList();

        GameManager.instance.OnPlayerPrefReset.AddListener(LoadShop);

        LoadShop();
        OpenShop(false);
    }

    public void OnClick(ScriptableSkin skinClic, ShopButton button)
    {
        if(_skinManager.IsSkinAlreadyBuy(skinClic.skinName))
        {
            print("Skin already bought !");
            foreach (var item in _shopButtonList)
                item.SetSelectState(false);

            button.SetSelectState(true);
            return;
        }

        if (_skinManager.TryBuySkin(skinClic))
        {
            print("Buy new Skin");
            foreach (var item in _shopButtonList)
                item.SetSelectState(false);

            button.SetSelectState(true);
        }
    }

    private void LoadShop()
    {
        if (_scriptableSkinList.Count == 0)
        {
            print("NO SKIN IN SHOP !");
            return;
        }

        for (int i = 0; i < _scriptableSkinList.Count; i++)
        {
            GameObject newButton = Instantiate(_skinButtonPrefabs, _shopButtonLayout);
            newButton.GetComponent<ShopButton>().Inistialize(_scriptableSkinList[i], this, _skinManager);
            _shopButtonList.Add(newButton.GetComponent<ShopButton>());
        }
    }

    public void SwitchShop()
    {
        _isShopOpen = !_isShopOpen;
        SetShopPosition(_isShopOpen);
    }

    public void OpenShop(bool value)
    {
        _isShopOpen = value;
        SetShopPosition(_isShopOpen);
    }

    private void SetShopPosition(bool shopOpenState)
    {
        //TODO dotween anim
        _scrollRect.inertia = false;
        _shopButtonLayout.anchoredPosition = Vector2.zero;
        _scrollRect.inertia = true;

        _shopContainer.anchoredPosition =
        new Vector2(_isShopOpen ? 0 : -_shopBackground.rect.width * 1.05f, 0);
    }
}
