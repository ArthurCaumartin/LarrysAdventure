using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class sEventDebug
{
    public bool drawDebug = true;
    public float size = 2f;
    public Color color = Color.white;
}

[Serializable]
public class SplineEvent
{
    public string ID;

    //TODO tow index creat code duplication :sadge:, add ind + event list to be clean
    public int splineIndex;
    [Space]
    public float distance;
    [SerializeField] private UnityEvent _event;
    [Space]
    public sEventDebug debug;
    public UnityEvent Event
    {
        get
        {
            if (!canCallEvent)
                return null;

            canCallEvent = false;
            return _event;
        }
    }

    private bool canCallEvent = true;
}
