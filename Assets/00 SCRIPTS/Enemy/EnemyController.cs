using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] protected float _speed;
    protected Rigidbody2D _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        this.RotateMoveToPlayer();
    }

    protected void RotateMoveToPlayer()
    {
        Quaternion rot = transform.rotation;
        Vector2 distance = GameManager.insantce.Player.transform.position - this.transform.position;
        if (distance.sqrMagnitude < 0.5f)
        {
            _rigidbody.velocity = Vector2.zero;
            return;
        }
        float dir = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg - 90;
        rot.eulerAngles = new Vector3(0, 0, dir);
        transform.rotation = rot;

        _rigidbody.velocity = this.transform.up * _speed;
    }

}
