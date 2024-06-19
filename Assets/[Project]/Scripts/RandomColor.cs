using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    [SerializeField] private List<Color> _colorList;

    void Start()
    {
        GetComponent<SpriteRenderer>().color = _colorList[Random.Range(0, _colorList.Count)];
    }
}
