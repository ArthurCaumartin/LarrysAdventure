using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class SplineTerrain : MonoBehaviour
{
    [SerializeField] private SplineContainer _levelSpline;
    [Space]
    [SerializeField] private int _indexToRenderOn = 0;
    [SerializeField] private int _startWidth;
    [SerializeField] private int _pointCount;

    private LineRenderer _line;

    void OnValidate()
    {
        YAAA();
    }

    private void YAAA()
    {
        if (!_levelSpline)
        {
            print(gameObject.name + " fo mettre la level spline dans le script");
            return;
        }

        if (_pointCount < 0)
            return;

        if (!_line)
            _line = GetComponent<LineRenderer>();

        _line.startWidth = _startWidth;
        _line.positionCount = _pointCount;
        for (int i = 0; i < _pointCount; i++)
        {
            _line.SetPosition(i, _levelSpline[_indexToRenderOn].EvaluatePosition(Mathf.InverseLerp(0, _pointCount, i)));
        }
    }
}
