using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    private Vector2 _movement;
    private Rigidbody2D _myBody;
    private Animator _myAnimator;

    [SerializeField] private int _speed = 5;

    void Awake()
    {
        _myBody = GetComponent<Rigidbody2D>();
        _myAnimator = GetComponent<Animator>();
    }

    public void OnMovement(InputValue value)
    {
        _movement = value.Get<Vector2>();
        if(_movement.x != 0 || _movement.y != 0)
        {
            _myAnimator.SetFloat("x", _movement.x);
            _myAnimator.SetFloat("y", _movement.y);
            _myAnimator.SetBool("isWalking", true);
        }
        else _myAnimator.SetBool("isWalking", false);
    }

    private void FixedUpdate()
    {
        _myBody.velocity = _movement * _speed;
    }
}
