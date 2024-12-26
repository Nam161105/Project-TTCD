using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Move : MonoBehaviour
{
    [SerializeField] protected float _speed;
    protected Animator _animator;
    [SerializeField] protected GunController _gunController;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        this.Move();
        this.Turning();
    }

    protected void Move()
    {
        Vector2 dis = GameManager.insantce.Player.transform.position - this.transform.position;

        if(dis.sqrMagnitude > 50 + 0.1f)
        {
            this.transform.position = Vector3.Lerp(this.transform.position,
            GameManager.insantce.Player.transform.position, _speed * Time.deltaTime);
            _animator.SetBool("Run2", true);
        }
        else if(dis.sqrMagnitude <= 50 - 0.1f)
        {
            _animator.SetBool("Run2", false);
            _gunController.Damer();
        }
    }

    protected void Turning()
    {
        float distance = GameManager.insantce.Player.transform.position.x - this.transform.position.x;
        if(distance > 0)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
