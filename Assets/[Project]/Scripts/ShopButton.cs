using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
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
    }

    public void OnClick()
    {
        _shop.OnClick(_scriptableSkin);
    }
}
