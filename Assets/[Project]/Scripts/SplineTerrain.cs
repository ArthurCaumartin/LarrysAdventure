using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class SplineTerrain : MonoBehaviour
{
    [SerializeField] private SplineContainer _levelSpline;
    [Space]
    [SerializeField] private int _startWidth;
    [SerializeField] private int _pointCount;

    private LineRenderer _line;

    void Start()
    {
        YAAA();
    }

    void OnValidate()
    {
        Start();
    }

    private void YAAA()
    {
        if(!_levelSpline || _pointCount < 0)
            return;
        
        if (!_line)
            _line = GetComponent<LineRenderer>();

        _line.startWidth = _startWidth;
        _line.positionCount = _pointCount;
        for (int i = 0; i < _pointCount; i++)
        {
            _line.SetPosition(i, _levelSpline.EvaluatePosition(Mathf.InverseLerp(0, _pointCount, i)));
        }
    }
}
