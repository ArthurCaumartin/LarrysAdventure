using System;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;

public class LevelEvent : MonoBehaviour
{
    [SerializeField] private SplineContainer _splineContainer;
    [SerializeField] private AnimateAtHome _animate;
    [SerializeField] private List<SplineEvent> _splineEventList;

    private float _speedMult = 1;
    public float SpeedMult { get => _speedMult; }


    void Update()
    {
        float distance = _animate.Distance;
        foreach (var splineEvent in _splineEventList)
        {
            if (splineEvent.splineIndex == _animate.SplineIndex)
            {
                if (splineEvent.startDistance < distance && splineEvent.startDistance + 5f > distance)
                {
                    print(splineEvent.ID + " start");
                    splineEvent.StartEvent?.Invoke();
                }

                if (splineEvent.endDistance < distance && splineEvent.endDistance + 5f > distance)
                {
                    print(splineEvent.ID + " end");
                    splineEvent.EndEvent?.Invoke();
                }
            }
        }
    }

    public void ChangeSpline(string indexString)
    {
        Vector3 pos = _splineContainer[_animate.SplineIndex].EvaluatePosition(_animate.Distance / _animate.Lenght);
        Vector3 normal = _splineContainer.EvaluateUpVector(_animate.Distance / _animate.Lenght);
        normal = Vector3.Cross(_splineContainer.EvaluateTangent(_animate.Distance / _animate.Lenght), normal);
        Vector3 playerPos = _animate.GetComponentInChildren<PlayerMovement>().transform.position;
        float dot = Vector3.Dot((playerPos - pos).normalized, normal);

        int topIndex = int.Parse(indexString.Split(' ')[0]);
        int botIndex = int.Parse(indexString.Split(' ')[1]);
        print("T = " + topIndex + " B = " + botIndex + " ||| " + "go to : " + (dot > 0 ? "Tot" : "Bop"));

        if (dot > 0)
            _animate.ChangeSplineIndex(topIndex);

        if (dot < 0)
            _animate.ChangeSplineIndex(botIndex);
    }

    public void GoBackOnMainSpline()
    {
        _animate.ChangeSplineIndex(0);
    }

    public void SetSpeedMult(float value)
    {
        float startValue = _speedMult;
        DOTween.To((time) =>
        {
            _speedMult = Mathf.Lerp(startValue, value, time);
        }, 0, 1, 1);
    }

    void OnDrawGizmos()
    {
        foreach (var item in _splineEventList)
        {
            Spline spline = _splineContainer[item.splineIndex];
            float lenth = spline.GetLength();
            if (item.debug.drawDebug)
            {
                Gizmos.color = item.debug.color;
                Gizmos.DrawSphere(spline.EvaluatePosition(item.startDistance / lenth), item.debug.size);
                Gizmos.DrawSphere(spline.EvaluatePosition(item.endDistance / lenth), item.debug.size * .6f);
            }
        }
    }
}
