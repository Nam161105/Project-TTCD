using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : EnemyBase
{

    [SerializeField] protected GunController _gunController;
    protected override void MoveToPlayer()
    {
        Vector2 dis = GameManager.insantce.Player.transform.position - this.transform.position;

        if (dis.sqrMagnitude > 50 + 0.5f)
        {
            this.transform.position = Vector3.Lerp(this.transform.position,
            GameManager.insantce.Player.transform.position, _speed * Time.deltaTime);
            _animator.SetTrigger(CONSTANT._runAni);
        }
        else if (dis.sqrMagnitude <= 50 - 0.5f)
        {
            _animator.SetTrigger(CONSTANT._idleAni);
            _gunController.Shoot();
        }
    }


}
