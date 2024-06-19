using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ObstacleMover : MonoBehaviour
{
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;

    void Update()
    {
        float time = Mathf.Sin(Time.time * _speed);
        time = Mathf.InverseLerp(-1, 1, time);
        transform.position = Vector2.Lerp(_pointA.position, _pointB.position, time);

        transform.Rotate(new Vector3(0, 0, _rotateSpeed) * Time.deltaTime);
    }
}
