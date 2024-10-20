using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpByScale : MonoBehaviour
{
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private Vector2 _startScale;
    [SerializeField] private Vector2 _goalScale;
    [SerializeField] private float _speed;
     private float _current, _target;


    private void Awake()
    {
        _startScale = transform.localScale;
    }

    void Update()
    {


        if (transform.localScale.x == _startScale.x && transform.localScale.y == _startScale.y)
        {
            _target = 1;
        }
        else if (transform.localScale.x == _goalScale.x && transform.localScale.y == _goalScale.y)
        {
            _target = 0;
        }

        _current = Mathf.MoveTowards(_current, _target, _speed * Time.deltaTime);

        transform.localScale = Vector2.Lerp(_startScale,  _goalScale, _curve.Evaluate(_current));
    }
}
