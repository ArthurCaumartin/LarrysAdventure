using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;

public class PlayerSkinSetter : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _headRenderer;
    [SerializeField] private LineRenderer _lineRenderer;

    private List<SpriteRenderer> _bodyPartRendererList = new List<SpriteRenderer>();

    public void Initialize(List<Transform> bodyPartList)
    {
        for (int i = 0; i < bodyPartList.Count; i++)
        {
            _bodyPartRendererList.Add(bodyPartList[i].GetComponent<SpriteRenderer>());
        }
    }

    public void SetPlayerSkin()
    {
        ScriptableSkin skin = SkinManager.CurrentSkin;
        if (skin == null)
            return;

        _headRenderer.sprite = skin.renderData.headSprite;
        
        _lineRenderer.enabled = skin.renderData.isBodyLine;

        if (skin.renderData.isBodyLine)
        {
            _lineRenderer.sharedMaterial.SetTexture("_MainTex", skin.renderData.lineBodyTex);
            foreach (var item in _bodyPartRendererList)
                item.GetComponent<SpriteRenderer>().enabled = false;
            return;
        }

        foreach (var item in _bodyPartRendererList)
        {
            foreach (var p in _bodyPartRendererList)
                p.GetComponent<SpriteRenderer>().enabled = true;
            item.GetComponent<SpriteRenderer>().sprite = skin.renderData.bodyPart;
        }
    }
}
