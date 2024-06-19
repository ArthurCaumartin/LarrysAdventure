using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public class MySplineAnimate : MonoBehaviour
{
    [SerializeField] private LevelEvent _levelEvent;
    [SerializeField] private float _speed;
    [SerializeField] private SplineContainer _splineContainer;
    [SerializeField] private int _splineIndex;
    [Space]
    private float _distance;
    private Spline _currentSpline;
    private float _currentSplineLenght;

    void Start()
    {
        _currentSpline = _splineContainer[_splineIndex];
        _currentSplineLenght = _currentSpline.GetLength();
    }

    void Update()
    {
        //TODO compute une nouvelle distance au switch d'index avec le point le plus proche de core sur la nouvelle spline

        _distance += Time.deltaTime * _speed * _levelEvent.SpeedMult;
        transform.position = _currentSpline.EvaluatePosition(_distance / _currentSplineLenght);
        if (_distance >= _currentSpline.GetLength())
            _distance = 0;
    }

    public void ChangeSplineIndex(int newIndex)
    {
        _splineIndex = newIndex;
        _currentSpline = _splineContainer[_splineIndex];
        _currentSplineLenght = _currentSpline.GetLength();

        SplineUtility.GetNearestPoint(_currentSpline, transform.position, out float3 nearest, out float time);
        _distance = _currentSplineLenght * time;
    }

    public float Lenght
    {
        get => _currentSplineLenght;
    }

    public float Distance
    {
        get => _distance;
    }

    public int SplineIndex
    {
        get => _splineIndex;
    }
}