using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Type : ")]
    [SerializeField] private bool _lerp = false;
    [SerializeField] private bool _damp = false;
    [Space]
    [SerializeField] private float _speed = 0.1f;
    private bool _isScreenClicked = false;
    private Vector2 _worldInputVector;
    private Camera mainCam;
    private Vector2 dampVelocity;

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        Vector2 moveTarget = Vector2.zero;
        if (_isScreenClicked)
        {
            print("Move");
            if (_lerp)
                moveTarget = Vector2.Lerp(transform.position, _worldInputVector, Time.deltaTime);
            if (_damp)
                moveTarget = Vector2.SmoothDamp(transform.position, _worldInputVector, ref dampVelocity, _speed, Mathf.Infinity, Time.deltaTime);
        }
        else
            moveTarget = transform.position;

        transform.position = moveTarget;
    }

    private void OnPointerClic(InputValue value)
    {
        _isScreenClicked = value.Get<float>() > .5f;
    }

    private void OnPointerMove(InputValue value)
    {
        _worldInputVector = mainCam.ScreenToWorldPoint(value.Get<Vector2>());
    }

    private void OnGUI()
    {
        _speed = GUI.HorizontalSlider(new Rect(350, 10, 600, 10), _speed, 0.01f, 5);

        if (GUI.Button(new Rect(10, 10, 150, 100), "Lerp"))
        {
            _damp = false;
            _lerp = true;
        }

        if (GUI.Button(new Rect(170, 10, 150, 100), "Damp"))
        {
            _damp = true;
            _lerp = false;
        }
    }
}
