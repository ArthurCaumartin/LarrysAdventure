using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSetter : MonoBehaviour
{
    [SerializeField] private int _startValue;

    [ContextMenu("SetOrder")]
    public void SetOrder()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<SpriteRenderer>().sortingOrder = (int)(i + _startValue);
        }
    }
}
