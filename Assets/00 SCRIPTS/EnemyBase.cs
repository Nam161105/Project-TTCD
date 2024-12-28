using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, IDameage
{
    [SerializeField] protected float _speed;
    [SerializeField] protected float maxHp;
    [SerializeField] protected float currentHp;
    [SerializeField] protected int dame;
    protected Animator _animator;

    protected virtual void OnEnable()
    {
        currentHp = maxHp;
    }
    protected virtual void Start()
    {
        _animator = GetComponent<Animator>();
        currentHp = maxHp;
    }

    protected virtual void Update()
    {
        this.MoveToPlayer();
        this.Turning();
    }

    protected virtual void MoveToPlayer()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position,
            GameManager.insantce.Player.transform.position, _speed * Time.deltaTime);
        _animator.SetBool("Run", false);

    }

    protected virtual void Turning()
    {
        float distance = GameManager.insantce.Player.transform.position.x - this.transform.position.x;
        if (distance > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (distance < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    public virtual void TakeDamage(float dame)
    {
        currentHp -= dame;
        if (currentHp <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        ExpManager.Instance.LevelSystem();
        this.gameObject.SetActive(false);
    }


    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IDameage iscanDmg = collision.gameObject.GetComponent<IDameage>();
            if (iscanDmg != null)
            {
                iscanDmg.TakeDamage(dame);
            }
        }
    }
}
