using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;

public class PlayerSkinSetter : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _headRenderer;
    [SerializeField] private LineRenderer _lineRenderer;

    public Texture2D bodyTexture;

    public void SetPlayerSkin(List<Transform> partList)
    {
        ScriptableSkin skin = SkinManager.CurrentSkin;
        if (skin == null)
            return;

        _headRenderer.sprite = skin.renderData.headSprite;
        _lineRenderer.enabled = skin.renderData.isBodyLine;
        if (skin.renderData.isBodyLine)
        {
            _lineRenderer.sharedMaterial.SetTexture("_MainTex", skin.renderData.lineBodyTex);
            foreach (var item in partList)
                item.GetComponent<SpriteRenderer>().enabled = false;
            return;
        }

        foreach (var item in partList)
        {
            foreach (var p in partList)
                p.GetComponent<SpriteRenderer>().enabled = true;
            item.GetComponent<SpriteRenderer>().sprite = skin.renderData.bodyPart;
        }
    }
}
