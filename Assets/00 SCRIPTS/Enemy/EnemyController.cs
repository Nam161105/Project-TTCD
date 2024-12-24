using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] protected float _speed;
    protected Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        this.MoveToPlayer();
        this.Turning();
    }

    protected void MoveToPlayer()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position,
            GameManager.insantce.Player.transform.position, _speed * Time.deltaTime);
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
