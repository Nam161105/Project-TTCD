using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] protected float _speed;
    protected Rigidbody2D _rigi;
    protected Vector2 _movement;

    void Start()
    {
        _rigi = GetComponent<Rigidbody2D>();
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
    }

    protected void Moving()
    {
        _rigi.velocity = _movement * _speed;
    }
}
