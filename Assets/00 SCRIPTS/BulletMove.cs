using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    protected Rigidbody2D rb;
    [SerializeField] protected float _speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    private void Update()
    {
        this.MoveBullet();
    }

    protected void MoveBullet()
    {
        rb.velocity = this.transform.up * _speed;
    }
}
