using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementTime = 0.1f;
    private bool _isScreenClicked = false;
    private Vector2 _inputScreenPos;
    private Camera _mainCam;
    private Vector2 _dampVelocity;
    private Rigidbody2D _rigidbody;
    private Vector3 _lastFramePosition;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _mainCam = Camera.main;
    }

    void Update()
    {
        if(transform.parent == null)
        {
            print("NO PARENT | PLAYER NEED PARENT le pauvre :'(");
            return;
        }

        Vector2 moveTarget = Vector2.zero;
        if (_isScreenClicked)
        {
            moveTarget = Vector2.SmoothDamp(transform.localPosition
                                          , transform.parent.InverseTransformPoint(_mainCam.ScreenToWorldPoint(_inputScreenPos))
                                          , ref _dampVelocity, _movementTime, Mathf.Infinity, Time.deltaTime);
        }
        else
            moveTarget = transform.localPosition;

        transform.localPosition = moveTarget;
        // _rigidbody.MovePosition(moveTarget);

        _lastFramePosition = transform.position;
    }

    private void OnPointerClic(InputValue value)
    {
        _isScreenClicked = value.Get<float>() > .5f;
    }

    private void OnPointerMove(InputValue value)
    {
        // print(value.Get<Vector2>());
        _inputScreenPos = value.Get<Vector2>();
    }
}
