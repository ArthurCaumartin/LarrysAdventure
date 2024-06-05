using UnityEngine;
using System;

[Serializable]
public class SkinRenderData
{
    public Sprite eggSprite;
    public Sprite headSprite;
    public bool isBodyLine;
    public Sprite bodyPart;
    public Texture2D lineBodyTex;

    //TODO faire un apelle de fonction qui send le bon sprite en fonction de isBodyLine
}

[CreateAssetMenu(menuName = "LarrysAdventure/Skin ٩(^‿^)۶")]
public class ScriptableSkin : ScriptableObject
{
    public string skinName;
    public int coinPrice = 10;
    public SkinRenderData renderData;
}
