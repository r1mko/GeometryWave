using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LerpByPos : MonoBehaviour
{
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private Vector2 _goalPosition;
    [SerializeField] private Vector2 _startPosition;
    [SerializeField] private float _speed;
    private float _current, _target;


    private void Awake()
    {
        _startPosition = transform.position;
    }

    void Update()
    {
        if (transform.position.x == _startPosition.x && transform.position.y == _startPosition.y)
        {
            _target = 1;
        }
        else if (transform.position.x == _goalPosition.x && transform.position.y == _goalPosition.y)
        {
            _target = 0;
        }

        _current = Mathf.MoveTowards(_current, _target, _speed * Time.deltaTime);

        transform.position = Vector2.Lerp(_startPosition, _goalPosition, _curve.Evaluate(_current));
    }

}
