using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private Color _unSelectColor;
    [SerializeField] private Color _SelectColor;
    private ScriptableSkin _scriptableSkin;
    private Shop _shop;

    public void Inistialize(ScriptableSkin skin, Shop shop)
    {
        _scriptableSkin = skin;
        _shop = shop;
    }

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
        SetSelectState(false);
    }

    public void OnClick()
    {
        _shop.OnClick(_scriptableSkin, this);
    }

    public void SetSelectState(bool value)
    {
        GetComponent<Image>().color = value ? _SelectColor : _unSelectColor;
    }
}
