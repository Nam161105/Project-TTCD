using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] protected float _speed;
    protected Rigidbody2D _rigi;
    protected Animator _animator;
    private void Start()
    {
        _rigi = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        this.MoveToPlayer();
        this.Turning();
    }

    protected void MoveToPlayer()
    {
        Vector2 distance = GameManager.insantce.Player.transform.position - this.transform.position;

        _rigi.velocity = distance * _speed;
        _animator.SetBool("Run", false);

    }

    protected void Turning()
    {
        float distance = GameManager.insantce.Player.transform.position.x - this.transform.position.x;
        if(distance > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(distance < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

}
