using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMove : MonoBehaviour
{
    [SerializeField] protected float _speed;
    protected Rigidbody2D _rg;
    protected Vector2 _dir;

    private void Start()
    {
        _rg = GetComponent<Rigidbody2D>();
    }
    public void SetDir(Vector2 dir)
    {
        _dir = dir.normalized;
    }

    private void Update()
    {
        this.MoveBullet();
    }

    protected void MoveBullet()
    {
        _rg.velocity = _dir * _speed;    
    }
}
