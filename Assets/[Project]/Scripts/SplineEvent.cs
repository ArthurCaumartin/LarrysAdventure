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
    public int startSplineIndex;
    public int endSplineIndex;
    [Space]
    public float startDistance;
    public float endDistance;
    [SerializeField] private UnityEvent _startEvent;
    [SerializeField] private UnityEvent _endEvent;
    [Space]
    public sEventDebug debug;
    public UnityEvent StartEvent
    {
        get
        {
            if (!canCallStart)
                return null;

            canCallStart = false;
            return _startEvent;
        }
    }

    public UnityEvent EndEvent
    {
        get
        {
            if (!canCallEnd)
                return null;

            canCallEnd = false;
            return _endEvent;
        }
    }

    private bool canCallStart = true;
    private bool canCallEnd = true;
}
