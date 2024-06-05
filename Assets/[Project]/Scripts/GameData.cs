using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Level
{
    [HideInInspector] public string ID;
    public string sceneName;
    // [Range(0, 3)] public int fruitTaken;
    public bool[] fruitTaken = new bool[3];
}

[CreateAssetMenu(menuName = "LarrysAdventure/GameData ✿ڿڰۣ——")]
public class GameData : ScriptableObject
{
    public int coinQuantity;
    public ScriptableSkin baseSkin;
    public List<ScriptableSkin> skinList;
    public List<Level> levelList;

    private void OnValidate()
    {
        if (levelList.Count == 0)
        {
            for (int i = 0; i < levelList.Count; i++)
                levelList[i].ID = "Level_" + (i + 1);
        }
    }
}
