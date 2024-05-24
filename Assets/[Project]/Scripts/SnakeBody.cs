using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    [SerializeField] private bool DEBUG = false;
    [Space]
    [SerializeField] private GameObject _bodyPartPrefabs;
    [SerializeField] private int _bodyLenght;
    [SerializeField] private float _lineQuality = .2f;
    [SerializeField] private float _bodyPartOffset = .4f;
    [SerializeField] private List<Transform> _bodyPartList = new List<Transform>();

    private Rigidbody2D _playerRigidbody;

    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();

        _bodyPartList.Add(transform);

        for (int i = 0; i < _bodyLenght; i++)
        {
            GameObject newPart = Instantiate(_bodyPartPrefabs, transform);
            newPart.transform.localPosition = new Vector3(-1, 0, 0) * (i + 1);
            newPart.transform.parent = null;
            _bodyPartList.Add(newPart.transform);
            _headTrackPoints.Add(newPart.transform.position);
        }
    }

    // public struct Point
    // {
    //     public Vector3 position;
    //     public float lengthToPrevious;
    //     public Point(Vector3 position, Vector3 lastPos)
    //     {
    //         this.position = position;
    //         lengthToPrevious = Vector3.Distance(position, lastPos);
    //     }
    // }
    // public List<Point> points;


    public List<Vector3> _headTrackPoints;
    public Vector3 LerpOver(float distance)
    {
        if (_headTrackPoints.Count == 0) return Vector3.zero;
        if (_headTrackPoints.Count == 1) return _headTrackPoints[0];

        float lenthWithLast = 0;

        // si tu n'insere pas la position de la tete au debut de la liste
        // for (int i = 1; i < positions.Count; i++)
        // Vector3 last = points[points.Count-1];

        Vector3 lastPointCreate = _headTrackPoints[_headTrackPoints.Count - 1];

        //! Lis la liste a l'envers
        for (int i = _headTrackPoints.Count - 2; i > -1; i--)
        {
            float distanceWithLastPoint = Vector3.Distance(lastPointCreate, _headTrackPoints[i]);

            if (lenthWithLast + distanceWithLastPoint > distance)
                return Vector3.Lerp(lastPointCreate, _headTrackPoints[i],
                                    Mathf.InverseLerp(lenthWithLast, lenthWithLast + distanceWithLastPoint, distance));

            lenthWithLast += distanceWithLastPoint;
            lastPointCreate = _headTrackPoints[i];
        }

        return lastPointCreate;
    }

    void Update()
    {
        // add point ?
        if (_headTrackPoints.Count > 1)
        {
            if (Vector3.Distance(_headTrackPoints[_headTrackPoints.Count - 1], transform.position) > _lineQuality)
            {
                _headTrackPoints.Add(transform.position);
                // check if toomuch points -> RemoveAt 0
                if (_headTrackPoints.Count > _bodyLenght * 200)
                    _headTrackPoints.RemoveAt(0);
            }
        }

        for (int i = 1; i < _bodyPartList.Count; i++)
            _bodyPartList[i].position = LerpOver(i * _bodyPartOffset);

        for (int i = 1; i < _bodyPartList.Count; i++)
        {
            Vector3 newUp = _bodyPartList[i - 1].transform.position - _bodyPartList[i].transform.position;
            _bodyPartList[i].transform.up = newUp.normalized;
        }
    }

    void OnDrawGizmos()
    {
        if(!DEBUG)
            return;
        Gizmos.color = Color.green;
        foreach (var item in _headTrackPoints)
        {
            Gizmos.DrawSphere(item, .3f);
        }
    }
}
