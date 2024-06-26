using UnityEngine;
using DG.Tweening;
using System;

public class Transitioner : MonoBehaviour
{
    public static Transitioner instance;

    [Header("Scene Transition :")]
    [SerializeField] private float _larryTransitionDuration = 1f;
    [SerializeField] private RectTransform _larrysContainer;

    [Header("Fast Transition :")]

    [SerializeField] private float _resetAnimationDuration = 1f;
    [SerializeField] private float _rotateSpeed = 25f;
    [SerializeField] private RectTransform _resetLevelImage;


    private Vector2 _larryContainerOriginePos;

    private void Awake()
    {
        transform.parent = null;
        if (instance)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        _larryContainerOriginePos = _larrysContainer.anchoredPosition;
        _resetLevelImage.gameObject.SetActive(false);
    }

    public void FastTransition(Action toDoInTransition = null, Action toDoAfter = null)
    {
        _resetLevelImage.localScale = Vector3.zero;
        _resetLevelImage.gameObject.SetActive(true);

        DOTween.To((time) =>
        {
            _resetLevelImage.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, time);
            _resetLevelImage.transform.Rotate(new Vector3(0, 0, _rotateSpeed));
        }, 0, 1, _resetAnimationDuration / 2)
        .SetUpdate(true)
        .SetEase(Ease.Linear)
        .OnComplete(() =>
        {
            _resetLevelImage.transform.eulerAngles = Vector3.zero;
            toDoInTransition?.Invoke();
            DOTween.To((time) =>
            {
                _resetLevelImage.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, time);
                _resetLevelImage.transform.Rotate(new Vector3(0, 0, _rotateSpeed));
            }, 0, 1, _resetAnimationDuration / 2)
            .SetDelay(.5f)
            .SetUpdate(true)
            .OnComplete(() =>
            {
                _resetLevelImage.gameObject.SetActive(false);
                toDoAfter?.Invoke();
            });
        });
    }

    public void SceneTransition(Action toDoInTransition = null, Action toDoAfter = null, bool initMenu = false)
    {
        _larrysContainer.anchoredPosition = _larryContainerOriginePos;
        _larrysContainer.gameObject.SetActive(true);
        
        Vector2 startPos = _larrysContainer.anchoredPosition;
        Vector2 endPos = Vector2.zero;

        DOTween.To((time) =>
        {
            _larrysContainer.anchoredPosition = Vector2.Lerp(startPos, endPos, time);
        }, 0, 1, _larryTransitionDuration / 2)
        .SetUpdate(true)
        .OnComplete(() =>
        {
            toDoInTransition?.Invoke();

            startPos = _larrysContainer.anchoredPosition;
            endPos = new Vector2(2500, 0);

            DOTween.To((time) =>
            {
                _larrysContainer.anchoredPosition = Vector2.Lerp(startPos, endPos, time);
            }, 0, 1, _larryTransitionDuration / 2)
            .SetDelay(1f)
            .SetUpdate(true)
            .OnComplete(() =>
            {
                _larrysContainer.gameObject.SetActive(false);
                toDoAfter?.Invoke();

                if(initMenu)
                    GameManager.instance.Start();
            });
        });
    }
}
