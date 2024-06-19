using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class MainMenuElement : MonoBehaviour
{
    [SerializeField] private Vector2 showDirection;
    [SerializeField] private Vector2 hideDirection;
    private RectTransform _rectTransform;

    void Awake()
    {
        _rectTransform = (RectTransform)transform;
    }

    public void Show(float time, AnimationCurve curve)
    {
        gameObject.SetActive(true);
        Vector2 startPos = new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight) * showDirection;
        _rectTransform.anchoredPosition = startPos;

        _rectTransform.DOAnchorPos(Vector2.zero, time)
        .SetEase(curve);
    }

    public void Hide(float time, AnimationCurve curve, Action toDoAfter = null)
    {
        Vector2 targetPos = new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight) * -showDirection;
        _rectTransform.anchoredPosition = Vector2.zero;

        _rectTransform.DOAnchorPos(targetPos, time)
        .SetEase(curve)
        .OnComplete(() =>
        {
            toDoAfter?.Invoke();
            gameObject.SetActive(false);
        });

    }
}
