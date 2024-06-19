using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, _rotateSpeed) * Time.deltaTime);
    }
}
