using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private SpriteRenderer _sprite;
    private Vector3 _lastFramePosition;

    void Start()
    {
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 newDirection = transform.localPosition - _lastFramePosition;
        _sprite.transform.up = newDirection;
        _lastFramePosition = transform.localPosition;
    }
}
