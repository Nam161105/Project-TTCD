using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyTakeDmg : MonoBehaviour, IDameage
{
    [SerializeField] protected float maxHp;
    [SerializeField] protected float currentHp;

    private void OnEnable()
    {
        currentHp = maxHp;
    }
    private void Start()
    {
        currentHp = maxHp;
    }

    public void TakeDamage(float dame)
    {
        currentHp -= dame;
        if (currentHp <= 0)
        {
            Die();
        }
    }

    protected void Die()
    {
        ExpManager.Instance.LevelSystem();
        this.gameObject.SetActive(false);
    }
}
