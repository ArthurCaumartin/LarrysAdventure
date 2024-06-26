using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonAnimate : MonoBehaviour
{
    [SerializeField] private float _bounceOffset;
    [SerializeField] private float _bounceDuration;
    [Space]
    [SerializeField] private float _speed;
    [SerializeField] private float _offSet;
    private RectTransform _rectTransform;
    private Vector2 _startLocalPos;

    void Start()
    {
        _rectTransform = (RectTransform)transform;
        _startLocalPos = _rectTransform.anchoredPosition;

        _speed *= Random.value > .5f ? 1 : -1;
        _speed *= Random.Range(.8f, 1.2f);
    }

    void Update()
    {
        float remapX = Mathf.InverseLerp(-1, 1, Mathf.Cos(Time.time * _speed)) * _offSet;
        float remapY = Mathf.InverseLerp(-1, 1, Mathf.Sin(Time.time * _speed)) * _offSet;
        _rectTransform.anchoredPosition = _startLocalPos + new Vector2(remapX, remapY);
    }

    public void OnClic()
    {
        _rectTransform.DOScale(Vector3.one * _bounceOffset, _bounceDuration / 2)
        .SetEase(Ease.Linear)
        .OnComplete(() => _rectTransform.DOScale(Vector3.one, _bounceDuration / 2).SetEase(Ease.Linear));
    }
}
