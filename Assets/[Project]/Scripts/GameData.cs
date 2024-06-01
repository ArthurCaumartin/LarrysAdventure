using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct LevelState
{
    public bool IsLevelDone;
    public int FruitTaken;
}

[CreateAssetMenu(menuName = "LarrysAdventure/GameData")]
public class GameData : ScriptableObject
{
    [SerializeField] public int CoinQuantity;
    [Space]
    [SerializeField] public ScriptableSkin BaseSkin;
    [SerializeField] public List<ScriptableSkin> SkinList;
    [SerializeField] public List<LevelState> LevelStateList;
}
