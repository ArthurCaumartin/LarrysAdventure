using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefRecorder : MonoBehaviour
{
    public void SaveData(string name, int value)
    {
        PlayerPrefs.SetInt(name, value);
    }

    public int GetData(string name)
    {
        return PlayerPrefs.GetInt(name);
    }

    [ContextMenu("CLEAR ALL PROGRESSIONS !")]
    public void ClearAllProgression()
    {
        PlayerPrefs.DeleteAll();
    }
}
