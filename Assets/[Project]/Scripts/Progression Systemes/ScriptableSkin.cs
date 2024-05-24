using UnityEngine;
using System;

[Serializable]
public class SkinRenderData
{
    public Sprite headSprite;
}

[CreateAssetMenu(menuName = "LarrysAdventure/Skin")]
public class ScriptableSkin : ScriptableObject
{
    public string skinName;
    public int coinValue = 10;
    public SkinRenderData skinRenderData;
}
