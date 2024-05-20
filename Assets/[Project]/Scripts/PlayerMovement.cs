using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 0.1f;
    private bool _isScreenClicked = false;
    private Vector2 _inputScreenPos;
    private Camera _mainCam;
    private Vector2 _dampVelocity;

    void Start()
    {
        _mainCam = Camera.main;
    }

    void Update()
    {
        Vector2 moveTarget = Vector2.zero;
        if (_isScreenClicked)
        {
            moveTarget = Vector2.SmoothDamp(transform.localPosition
                                          , transform.parent.InverseTransformPoint(_mainCam.ScreenToWorldPoint(_inputScreenPos))
                                          , ref _dampVelocity, _speed, Mathf.Infinity, Time.deltaTime);
        }
        else
            moveTarget = transform.localPosition;

        transform.localPosition = moveTarget;
    }

    private void OnPointerClic(InputValue value)
    {
        _isScreenClicked = value.Get<float>() > .5f;
    }

    private void OnPointerMove(InputValue value)
    {
        _inputScreenPos = value.Get<Vector2>();
    }
}
