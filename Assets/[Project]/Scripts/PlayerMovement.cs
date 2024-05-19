using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 0.1f;
    private bool _isScreenClicked = false;
    private Vector2 _worldInputVector;
    private Camera mainCam;
    private Vector2 dampVelocity;
    private Vector3 _lastFramePosition;

    void Start()
    {
        mainCam = Camera.main;
        _lastFramePosition = transform.localPosition;
    }

    void Update()
    {
        transform.forward = (transform.localPosition - _lastFramePosition).normalized;

        Vector2 moveTarget = Vector2.zero;
        if (_isScreenClicked)
            moveTarget = Vector2.SmoothDamp(transform.position, _worldInputVector, ref dampVelocity, _speed, Mathf.Infinity, Time.deltaTime);
        else
            moveTarget = transform.position;

        transform.position = moveTarget;

        _lastFramePosition = transform.localPosition;
    }

    private void OnPointerClic(InputValue value)
    {
        _isScreenClicked = value.Get<float>() > .5f;
    }

    private void OnPointerMove(InputValue value)
    {
        _worldInputVector = mainCam.ScreenToWorldPoint(value.Get<Vector2>());
    }
}
