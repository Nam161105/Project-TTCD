using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullBullet : MonoBehaviour
{
    [SerializeField] protected float _speed;
    protected Rigidbody2D _rigi;
    protected Vector2 direction;
    private void Start()
    {
        _rigi = GetComponent<Rigidbody2D>();
        direction = (GameManager.insantce.Player.transform.position - this.transform.position).normalized;
    }

    private void Update()
    {
        this.DirectionAndMoveToPlayer();
    }



    protected void DirectionAndMoveToPlayer()
    {
        float dir = GameManager.insantce.Player.transform.position.x - this.transform.position.x;
        if (dir < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        
        _rigi.velocity = direction * _speed;
    }
}
