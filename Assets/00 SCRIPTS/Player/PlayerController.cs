using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] protected float _speed;
    protected Rigidbody2D _rigi;
    protected Vector2 _movement;
    protected Animator _animator;

    void Start()
    {
        _rigi = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        this.InputPlayer();

    }

    private void FixedUpdate()
    {
        this.Moving();
    }

    protected void InputPlayer()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        _movement.Normalize();
        _animator.SetBool("Run", true);
        if (_rigi.velocity == Vector2.zero)
        {
            _animator.SetBool("Run", false);
        }
        this.Turning();
    }

    protected void Turning()
    {
        if(_movement.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        } 
        else if(_movement.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    protected void Moving()
    {
        _rigi.velocity = _movement * _speed;
        
    }
}
