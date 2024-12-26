using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2TakeDmg : MonoBehaviour, IDameage
{
    [SerializeField] protected float currentHp;
    [SerializeField] protected float maxHp;


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
