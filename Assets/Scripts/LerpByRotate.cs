using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpByRotate : MonoBehaviour
{
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private Vector3 _goalRotationl;
    [SerializeField] private Vector3 _startRotation;
    [SerializeField] private float _speed;
    private float _current, _target;

    void Start()
    {
       // StartCoroutine(TargetOne());
    }

    void Update()
    {
        if (_current == 1)
        {
            _target = 0;
        }
        else if (_current == 0)
        {
            _target = 1;
        }

        _current = Mathf.MoveTowards(_current, _target, _speed * Time.deltaTime);

        transform.rotation = Quaternion.Lerp(Quaternion.Euler(_startRotation), Quaternion.Euler(_goalRotationl), _curve.Evaluate(_current));
    }

    /*private IEnumerator TargetOne()
    {
        _target = 1;
        yield return new WaitForSeconds(2f);
        StartCoroutine(TargetZero());
    }

    private IEnumerator TargetZero()
    {
        _target = 0;
        yield return new WaitForSeconds(2f);
        StartCoroutine(TargetOne());
    } */
}
