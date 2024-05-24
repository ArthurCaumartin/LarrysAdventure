using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    //TODO Layout height set with _scriptableSkinList.count

    [SerializeField] private GameObject _skinButtonPrefabs;
    [Space]
    [SerializeField] private RectTransform _shopContainer;
    [SerializeField] private RectTransform _shopBackground;
    [SerializeField] private RectTransform _shopButtonLayout;
    [Space]
    [SerializeField] private List<ScriptableSkin> _scriptableSkinList;
    private bool _isShopOpen = true;

    private void Start()
    {
        LoadShopButton();
        OpenShop(false);
    }

    public void OnClick(ScriptableSkin skinClic)
    {
        
    }

    private void LoadShopButton()
    {
        if(_scriptableSkinList.Count == 0)
        {
            print("NO SKIN IN SHOP !");
            return;
        }
        for (int i = 0; i < _scriptableSkinList.Count; i++)
        {
            GameObject newButton = Instantiate(_skinButtonPrefabs, _shopButtonLayout);
            newButton.GetComponent<ShopButton>().Inistialize(_scriptableSkinList[i], this);
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
        _shopContainer.anchoredPosition =
        new Vector2(_isShopOpen ? 0 : -_shopBackground.rect.width * 1.05f, 0);
    }
}
