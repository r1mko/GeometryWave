using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GravityController : MonoBehaviour
{
    [SerializeField] private GameObject deathParticle;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private Vector2 forceDirectionDown;
    [SerializeField] private Vector2 forceDirectionUp;

    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private Vector3 upRotation;
    [SerializeField] private Vector3 downRotation;
    [SerializeField] private float _speed;
    private float _current, _target;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _target = 1;
        }
        if (!Input.GetKey(KeyCode.Mouse0))
        {
            _target = 0;
        }
    }

    private void FixedUpdate()
    {
        if (_target == 1)
        {
            ToUp();
        }
        if (_target == 0)
        {
            ToDown();
        }
        _current = Mathf.MoveTowards(_current, _target, _speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(Quaternion.Euler(downRotation), Quaternion.Euler(upRotation), _curve.Evaluate(_current));
    }

    private void ToUp()
    {
        playerRb.velocity = forceDirectionUp;
    }

    private void ToDown()
    {
        playerRb.velocity = forceDirectionDown;
    }

    public void PlayerDeath()
    {
        GameObject explosion = Instantiate(deathParticle, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(explosion, 0.75f);
    }
}


